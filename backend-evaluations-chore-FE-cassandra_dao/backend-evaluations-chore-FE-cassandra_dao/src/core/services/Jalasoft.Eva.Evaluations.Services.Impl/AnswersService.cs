namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Dao;
    using Jalasoft.Eva.Evaluations.Dao.Mongo;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Services;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils;

    public class AnswersService : AbstractService, IAnswersService, IRegistrableFactory<IAnswersService>
    {
        private IDaoBuilder<IAnswersDao> answersDaoBuilder;
        private IDaoBuilder<IEvaluationsDao> evaluationsDaoBuilder;
        private IDaoBuilder<ITemplatesDao> templatesDaoBuilder;

        public AnswersService()
        {
        }

        public AnswersService(
            IDaoBuilder<IAnswersDao> answersDaoBuilder,
            IDaoBuilder<IEvaluationsDao> evaluationsDaoBuilder,
            IDaoBuilder<ITemplatesDao> templatesDaoBuilder)
        {
            this.answersDaoBuilder = answersDaoBuilder;
            this.evaluationsDaoBuilder = evaluationsDaoBuilder;
            this.templatesDaoBuilder = templatesDaoBuilder;
        }

        public IAnswersService CreateInstance()
        {
            var answersDaoBuilder = new AnswersStubDao();
            string dbConnection = ConfigurationManager.AppSettings["dbConnection"];
            string collection = ConfigurationManager.AppSettings["evaCollection"];
            var evaluationsDaoBuilder = new EvaluationsMongoDao(dbConnection, collection);
            var templatesDaoBuilder = new TemplatesStubDao();

            return new AnswersService(answersDaoBuilder, evaluationsDaoBuilder, templatesDaoBuilder);
        }

        public EvaluationScore CreateAnswers(Guid idEvaluation, EvaluationAnswer answersList)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info($"Checking if evaluation with id {idEvaluation} exists");
                var answersDao = this.answersDaoBuilder.Create();
                var evaluationsDao = this.evaluationsDaoBuilder.Create();
                var templatesDao = this.templatesDaoBuilder.Create();

                if (!evaluationsDao.EvaluationExists(idEvaluation))
                {
                    throw new ItemNotFoundServiceException($"Unable to find an evaluation with id {idEvaluation}");
                }

                var evaluation = evaluationsDao.GetEvaluation(idEvaluation);
                var template = templatesDao.GetTemplate(evaluation.IdTemplate);
                var evaluationTemplate = EvaluationScoreHelpers.GenerateEvaluationTemplate(template, evaluation);
                evaluationTemplate.AppendAnswers(answersList);
                var scoreService = ServicesFacade.Instance.GetScoreService();
                var caluculatedEvaluation = scoreService.CalculateScore(evaluationTemplate);

                Log.Info($"Creating answers for evaluation {idEvaluation}");
                caluculatedEvaluation.IdEvaluation = idEvaluation;
                caluculatedEvaluation.Date = DateTime.Now.ToUniversalTime();
                EvaluationScore newAnswers = answersDao.CreateAnswers(caluculatedEvaluation);

                Log.Info($"Evaluation answers created succesfully, Id {newAnswers.Id}");
                return newAnswers;
            });
        }

        public EvaluationScore GetAnswer(Guid idAnswer)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info($"Getting answers with ID {idAnswer}");
                var dao = this.answersDaoBuilder.Create();
                if (!dao.AnswersExist(idAnswer))
                {
                    throw new ItemNotFoundServiceException($"Unable to find answers with id {idAnswer}");
                }

                var evaluationAnswers = dao.GetAnswer(idAnswer);
                Log.Info($"Answers with ID {evaluationAnswers.Id} retrieved");
                return evaluationAnswers;
            });
        }

        public IList<EvaluationScore> GetAnswers(Guid idEvaluation)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Getting the list of answers for the evaluation with ID {0}", idEvaluation));
                var dao = this.answersDaoBuilder.Create();
                IList<EvaluationScore> evaluationAnswers = dao.GetAnswers(idEvaluation);
                Log.Info(string.Format("List of answers for evaluation : {0}", evaluationAnswers));
                return evaluationAnswers;
            });
        }
    }
}
