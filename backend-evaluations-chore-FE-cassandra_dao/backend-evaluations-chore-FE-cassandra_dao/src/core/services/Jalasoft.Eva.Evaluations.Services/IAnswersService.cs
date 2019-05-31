namespace Jalasoft.Eva.Evaluations.Services
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public interface IAnswersService
    {
        EvaluationScore CreateAnswers(Guid idEvaluation, EvaluationAnswer answersList);

        EvaluationScore GetAnswer(Guid idAnswer);

        IList<EvaluationScore> GetAnswers(Guid idEvaluation);
    }
}
