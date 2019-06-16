namespace Jalasoft.Eva.Evaluations.Services
{
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public interface IScoreService
    {
        EvaluationScore CalculateScore(EvaluationScore evaluation);
    }
}
