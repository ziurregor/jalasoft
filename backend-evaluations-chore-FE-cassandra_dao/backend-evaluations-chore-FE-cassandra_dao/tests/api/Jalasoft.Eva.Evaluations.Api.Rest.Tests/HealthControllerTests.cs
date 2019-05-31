namespace Jalasoft.Eva.Evaluations.Api.Rest.Tests
{
    using Jalasoft.Eva.Evaluations.Api.Rest.Controllers;
    using Jalasoft.Eva.Evaluations.Api.Rest.Tests.Helpers;
    using Jalasoft.Eva.Evaluations.Domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Xunit;

    public class HealthControllerTests : IClassFixture<GlobalFixture>
    {
        public HealthControllerTests()
        {
            this.Controller = new HealthController();
        }

        private HealthController Controller { get; set; }

        [Fact]
        public void TestGetHealth_Returns_Status_Ok()
        {
            var actual = this.Controller.GetHealth().Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestGetHealth_Returns_App_Status_Up()
        {
            var healthInfo = this.Controller.GetHealth().Result as ObjectResult;
            var actual = (healthInfo.Value as ApplicationHealthInfo).Status;
            var expected = ApplicationHealthStatus.Up;
            Assert.Equal(expected, actual);
        }
    }
}
