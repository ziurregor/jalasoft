namespace Jalasoft.Eva.Evaluations.Dao
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public interface IAnswersDao
    {
        EvaluationScore GetAnswer(Guid idAnswer);

        IList<EvaluationScore> GetAnswers(Guid idEvaluation);

        EvaluationScore CreateAnswers(EvaluationScore answersList);

        bool AnswersExist(Guid id);
    }
}
