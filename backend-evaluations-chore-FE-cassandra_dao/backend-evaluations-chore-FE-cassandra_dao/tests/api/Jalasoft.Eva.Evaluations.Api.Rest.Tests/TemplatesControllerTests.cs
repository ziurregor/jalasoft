namespace Jalasoft.Eva.Evaluations.Api.Rest.Tests
{
    using Jalasoft.Eva.Evaluations.Api.Rest.Controllers;
    using Jalasoft.Eva.Evaluations.Api.Rest.Tests.Helpers;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Xunit;

    public class TemplatesControllerTests : IClassFixture<GlobalFixture>
    {
        public TemplatesControllerTests()
        {
            this.SampleTemplate = new Template { Name = "Sample template" };
            this.Controller = new TemplatesController();
        }

        public Template SampleTemplate { get; set; }

        private TemplatesController Controller { get; set; }

        [Fact]
        public void TestPostTemplate_Return_Status_Created()
        {
            var actual = this.Controller.PostTemplate(this.SampleTemplate).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status201Created;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestGetTemplates_Returns_Status_Ok()
        {
            var actual = this.Controller.GetTemplates().Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestDeleteTemplate_Return_Status_NoContent()
        {
            var template = "11111111-1111-1111-1111-111111111113";
            var actual = this.Controller.DeleteTemplate(template) as IStatusCodeActionResult;
            var expected = StatusCodes.Status204NoContent;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestGetTemplate_Returns_Status_Ok()
        {
            var template = "11111111-1111-1111-1111-111111111112";
            var actual = this.Controller.GetTemplate(template).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestPatchTemplate_Returns_Status_No_Content()
        {
            var template = "11111111-1111-1111-1111-111111111112";
            var actual = this.Controller.PatchTemplate(template, this.SampleTemplate) as IStatusCodeActionResult;
            var expected = StatusCodes.Status204NoContent;
            Assert.Equal(expected, actual.StatusCode);
        }
    }
}
