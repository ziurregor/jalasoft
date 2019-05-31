namespace Jalasoft.Eva.Evaluations.Dao.Cassandra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class AnswersDao : AbstractCassandraDao, IAnswersDao, IDaoBuilder<IAnswersDao>
    {
        public AnswersDao(IConnectionFactory connection)
            : base(connection)
        {
        }

        public bool AnswersExist(Guid id)
        {
            return this.Execute((mapper) =>
            {
                try
                {
                    mapper.Single<EvaluationScore>("WHERE id = ?", id);
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            });
        }

        public IAnswersDao Create()
        {
            // TODO: Se the way to use the global variables to configure the connection
            return new AnswersDao(new CassandraConnection("answers", "localhost"));
        }

        public EvaluationScore CreateAnswers(EvaluationScore answersList)
        {
            answersList.Id = Guid.NewGuid();

            return this.Execute((mapper) =>
            {
                mapper.Insert(answersList);
                var answer = mapper.Single<EvaluationScore>("WHERE id = ?", answersList.Id);
                return answer;
            });
            throw new NotImplementedException();
        }

        public EvaluationScore GetAnswer(Guid idAnswer)
        {
            return this.Execute(mapper =>
            {
               var evaluationScores = mapper.Single<EvaluationScore>("WHERE id = ?", idAnswer);
               return evaluationScores;
            });
        }

        public IList<EvaluationScore> GetAnswers(Guid idEvaluation)
        {
            return this.Execute(mapper =>
            {
                var answers = mapper.Fetch<EvaluationScore>("WHERE evaluation_id = ?", idEvaluation);
                return answers.ToList();
            });
        }
    }
}
