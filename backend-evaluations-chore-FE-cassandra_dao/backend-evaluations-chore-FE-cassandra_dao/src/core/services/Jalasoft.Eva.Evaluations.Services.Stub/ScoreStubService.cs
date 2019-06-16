namespace Jalasoft.Eva.Evaluations.Services.Stub
{
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class ScoreStubService : IScoreService, IRegistrableFactory<IScoreService>
    {
        public ScoreStubService()
        {
        }

        public IScoreService CreateInstance()
        {
            return new ScoreStubService();
        }

        public EvaluationScore CalculateScore(EvaluationScore evaluationTemplate)
        {
            return evaluationTemplate;
        }
    }
}
