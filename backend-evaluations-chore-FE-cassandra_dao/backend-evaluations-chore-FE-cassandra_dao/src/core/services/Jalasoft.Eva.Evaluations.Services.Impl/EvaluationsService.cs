namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Dao;
    using Jalasoft.Eva.Evaluations.Dao.Mongo;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Services;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Jalasoft.Eva.Evaluations.Services.Validators;

    public class EvaluationsService : AbstractService, IEvaluationsService, IRegistrableFactory<IEvaluationsService>
    {
        private IDaoBuilder<IEvaluationsDao> evaluationDaoBuilder;

        public EvaluationsService()
        {
        }

        public EvaluationsService(IDaoBuilder<IEvaluationsDao> daoBuilder)
        {
            this.evaluationDaoBuilder = daoBuilder;
        }

        public IList<Evaluation> GetEvaluations()
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info("Getting the evaluations");
                var dao = this.evaluationDaoBuilder.Create();
                return dao.GetEvaluations();
            });
        }

        public PaginatedList<Evaluation> GetEvaluations(QueryParameters queryParameters)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info("Getting the paginated evaluations");
                var dao = this.evaluationDaoBuilder.Create();
                return dao.GetEvaluations(queryParameters);
            });
        }

        public Evaluation GetEvaluation(Guid id)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Getting the evaluation with ID {0}", id));
                var dao = this.evaluationDaoBuilder.Create();
                if (!dao.EvaluationExists(id))
                {
                    throw new ItemNotFoundServiceException($"Unable to find an evaluation with id {id}");
                }

                var evaluation = dao.GetEvaluation(id);
                Log.Info(string.Format("Evaluation: {0}", evaluation));
                return evaluation;
            });
        }

        public IEvaluationsService CreateInstance()
        {
            string dbConnection = ConfigurationManager.AppSettings["dbConnection"];
            string collection = ConfigurationManager.AppSettings["evaCollection"];
            var daoBuilder = new EvaluationsMongoDao(dbConnection, collection);
            return new EvaluationsService(daoBuilder);
        }

        public void DeleteEvaluation(Guid id)
        {
            ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Attemping to delete Evaluation with ID {0}", id));
                var dao = this.evaluationDaoBuilder.Create();

                if (!dao.EvaluationExists(id))
                {
                    throw new ItemNotFoundServiceException($"Unable to find an evaluation with id {id}");
                }

                dao.DeleteEvaluation(id);
            });
        }

        public Evaluation CreateEvaluation(Evaluation evaluation)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info("Creating the Evaluation");
                IEvaluationsDao dao = this.evaluationDaoBuilder.Create();

                evaluation.CreationDate = DateTime.Now.ToUniversalTime();
                evaluation.EditDate = DateTime.Now.ToUniversalTime();

                var template = ServicesFacade.Instance.GetTemplatesService().GetTemplate(evaluation.IdTemplate);

                EvaluationValidator.Validate(evaluation, template);

                Evaluation newEvaluation = dao.CreateEvaluation(evaluation);

                Log.Info($"Evaluation Created Succesfully, Id {newEvaluation.Id}");
                return newEvaluation;
            });
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Attempting to update evaluation with ID {0}", evaluation.Id));
                var dao = this.evaluationDaoBuilder.Create();
                var id = evaluation.Id;

                if (!dao.EvaluationExists(id))
                {
                    throw new ItemNotFoundServiceException($"Unable to find an evaluation with id {id}");
                }

                if (evaluation.CreationDate != null)
                {
                    throw new InvalidItemServiceException("Bad arguments, cannot update existing evaluation Creation Date");
                }
                else if (evaluation.EditDate != null)
                {
                    throw new InvalidItemServiceException("Bad arguments, cannot update existing evaluation Edit Date");
                }

                evaluation.EditDate = DateTime.Now.ToUniversalTime();
                dao.UpdateEvaluation(evaluation);
            });
        }
    }
}
