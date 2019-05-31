namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using System.Linq;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils;

    public class ScoresService : AbstractService, IScoreService, IRegistrableFactory<IScoreService>
    {
        public ScoresService()
        {
        }

        private EvaluationScore EvaluationTemplate { get; set; }

        public IScoreService CreateInstance()
        {
            return new ScoresService();
        }

        public EvaluationScore CalculateScore(EvaluationScore evaluationScore)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                var calculator = new MathParserCalculator(evaluationScore);
                var calculated = calculator.Calculate();
                this.CalculateQualification(calculated);
                return calculated;
            });
        }

        private void CalculateQualification(EvaluationScore evaluationScore)
        {
            var qualification = evaluationScore.QualificationRanges.Where(range =>
            evaluationScore.Score <= range.End && evaluationScore.Score >= range.Start).FirstOrDefault();
            if (qualification != null)
            {
                evaluationScore.Qualification = qualification.Id;
            }
        }
    }
}
