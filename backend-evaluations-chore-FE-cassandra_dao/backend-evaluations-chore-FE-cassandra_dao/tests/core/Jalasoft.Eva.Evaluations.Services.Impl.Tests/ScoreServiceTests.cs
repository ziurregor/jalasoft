namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers;
    using Xunit;

    public class ScoreServiceTests
    {
        [Fact]
        public void TestCalculateScore()
        {
            var service = new ScoresService();
            var evaluation = Samples.CompleteEvaluation;
            var expected = 15;
            var actualEvaluation = service.CalculateScore(evaluation);
            var actual = actualEvaluation.Score;

            Assert.Equal(expected, actual);
        }
    }
}
