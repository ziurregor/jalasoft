namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class AnswersStubDao : IAnswersDao, IDaoBuilder<IAnswersDao>
    {
        public AnswersStubDao()
        {
        }

        public bool AnswersExist(Guid id)
        {
            return Memory.Answers.List.Exists(x => x.Id == id);
        }

        public IAnswersDao Create()
        {
            return new AnswersStubDao();
        }

        public EvaluationScore CreateAnswers(EvaluationScore answers)
        {
            answers.Id = Guid.NewGuid();

            Memory.Answers.List.Add(answers);
            return Memory.Answers.Get(answers.Id);
        }

        public EvaluationScore GetAnswer(Guid idAnswer)
        {
            return Memory.Answers.Get(idAnswer);
        }

        public IList<EvaluationScore> GetAnswers(Guid idEvaluation)
        {
            IList<EvaluationScore> answers = (IList<EvaluationScore>)Memory.Answers.List.Where(ea => ea.IdEvaluation == idEvaluation).ToList();
            return answers;
        }
    }
}
