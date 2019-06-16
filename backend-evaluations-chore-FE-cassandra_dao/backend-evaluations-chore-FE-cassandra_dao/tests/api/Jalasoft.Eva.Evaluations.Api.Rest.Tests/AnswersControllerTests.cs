namespace Jalasoft.Eva.Evaluations.Api.Rest.Tests
{
    using System;
    using Jalasoft.Eva.Evaluations.Api.Rest.Controllers;
    using Jalasoft.Eva.Evaluations.Api.Rest.Tests.Helpers;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Xunit;

    public class AnswersControllerTests : IClassFixture<GlobalFixture>
    {
        public AnswersControllerTests()
        {
            this.Controller = new AnswersController();
        }

        private AnswersController Controller { get; set; }

        [Fact]
        public void TestGetEvaluationAnswers_Returns_Status_Ok()
        {
            var answer = Guid.Parse("11111111-1111-1111-1111-111111666666");
            var actual = this.Controller.GetAnswer(answer).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestGetAnswers_Returns_Status_Ok()
        {
            var evaluation = Guid.Parse("11111111-1111-1111-1111-111111111112");
            var actual = this.Controller.GetAnswers(evaluation).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluationAnswers_ReturnStatusCreated()
        {
            var sampleAnswers = new EvaluationAnswer
            {
                IdEvaluation = Guid.NewGuid()
            };

            var id = sampleAnswers.IdEvaluation;
            var actual = this.Controller.PostAnswers(id, sampleAnswers).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status201Created;
            Assert.Equal(actual.StatusCode, expected);
        }
    }
}
