namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Xunit;

    public class AnswersServiceTests
    {
        private static Evaluation evaluation;

        public AnswersServiceTests()
        {
            evaluation = new EvaluationsStubDao().GetEvaluations()[1];
        }

        [Fact]
        public void TestGetAnswer_ReturnsNotNull()
        {
            var service = new AnswersService(new AnswersStubDao(), new EvaluationsStubDao(), new TemplatesStubDao());
            var actual = service.GetAnswer(Guid.Parse("11111111-1111-1111-1111-111111666666"));

            Assert.NotNull(actual);
        }

        [Fact]
        public void TestGetAnswers_ReturnsNotNull()
        {
            var service = new AnswersService(new AnswersStubDao(), new EvaluationsStubDao(), new TemplatesStubDao());
            var actual = service.GetAnswers(Guid.Parse("11111111-1111-1111-1111-111111111112"));

            Assert.NotNull(actual);
        }
    }
}
