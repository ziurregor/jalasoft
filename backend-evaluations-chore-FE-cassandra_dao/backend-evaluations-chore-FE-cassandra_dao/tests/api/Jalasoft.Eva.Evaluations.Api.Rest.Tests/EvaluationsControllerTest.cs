namespace Jalasoft.Eva.Evaluations.Api.Rest.Tests
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Api.Rest.Controllers;
    using Jalasoft.Eva.Evaluations.Api.Rest.Tests.Helpers;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Xunit;

    public class EvaluationsControllerTest : IClassFixture<GlobalFixture>
    {
        public EvaluationsControllerTest()
        {
            this.SampleEvaluation = new Evaluation { Name = "Sample evaluation", Headers = new List<Data>() };
            Memory.Templates.List.Add(
                new Template()
                {
                    Id = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                    EvalNameMaxChars = 150,
                    AllowedCharsRule = @"^[\w\s]+$",
                    ValueRequired = true,
                    Name = "Evaluation Header Test Template",
                    ScoreFormula = "sum(i, 0, questionsLength, questionResult(i))",
                    QualificationRules = new Dictionary<string, object>() { { "Min", 0 }, { "MinRanges", 1 } },
                    Headers = new List<DataField>
                    {
                        new TextField()
                        {
                            Id = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                            AllowedCharsRule = @"^[\w\s]+$",
                            ValueRequired = true,
                            Input = false,
                            Label = "Title",
                            Type = DataFieldType.Text,
                            MinChar = 4,
                            MaxChar = 150
                        }
                    }
                });
            this.Controller = new EvaluationsController();
        }

        public Evaluation SampleEvaluation { get; set; }

        private EvaluationsController Controller { get; set; }

        [Fact]
        public void Test_GetEvaluations_Return_Status_OK()
        {
            this.Controller.ControllerContext = new ControllerContext();
            this.Controller.ControllerContext.HttpContext = new DefaultHttpContext();
            (this.Controller.HttpContext.Request as DefaultHttpRequest).QueryString = new QueryString("?page%5Bnumber%5D=1&page%5Bsize%5D=10");
            var actual = this.Controller.GetEvaluations().Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestGetEvaluation_Return_Status_OK()
        {
            var actual = this.Controller.GetEvaluation("11111111-1111-1111-1111-111111111112").Result as ObjectResult;
            var expected = StatusCodes.Status200OK;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestDeleteEvaluation_Returns_Status_NoContent()
        {
            var idEvaluation = "f480b496-2356-402b-9fdc-a1893cc64e16";
            var actual = this.Controller.DeleteEvaluation(idEvaluation) as IStatusCodeActionResult;
            var expected = StatusCodes.Status204NoContent;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestPatchEvaluation_Returns_Status_No_Content()
        {
            var evaluation = "11111111-1111-1111-1111-111111111112";
            var actual = this.Controller.PatchEvaluation(evaluation, this.SampleEvaluation) as IStatusCodeActionResult;
            var expected = StatusCodes.Status204NoContent;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluation_returns_status_created()
        {
            var actual = this.Controller.PostEvaluation(this.SampleEvaluation).Result as IStatusCodeActionResult;
            var expected = StatusCodes.Status201Created;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluation_InvalidHeaderItem_EmptyString_returns_status_BadRequest()
        {
            this.SampleEvaluation.IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000");
            this.SampleEvaluation.Headers.Add(new Data()
            {
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                Value = string.Empty
            });

            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PostEvaluation(this.SampleEvaluation).Result as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluation_InvalidHeaderItem_MinCharViolation_returns_status_BadRequest()
        {
            this.SampleEvaluation.IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000");
            this.SampleEvaluation.Headers.Add(new Data()
            {
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                Value = "123"
            });

            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PostEvaluation(this.SampleEvaluation).Result as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluation_InvalidHeaderItem_MaxCharViolation_returns_status_BadRequest()
        {
            this.SampleEvaluation.IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000");
            this.SampleEvaluation.Headers.Add(new Data()
            {
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                Value = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
            });

            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PostEvaluation(this.SampleEvaluation).Result as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void TestCreateEvaluation_InvalidHeaderItem_ValueNotAlphanumeric_returns_status_BadRequest()
        {
            this.SampleEvaluation.IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000");
            this.SampleEvaluation.Headers.Add(new Data()
            {
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                Value = "!@ThisIsATittle@!"
            });

            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PostEvaluation(this.SampleEvaluation).Result as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void Test_patch_evaluation_invalid_hasCreationDate_returns_status_BadRequest()
        {
            this.SampleEvaluation.CreationDate = DateTime.Now;
            var evaluation = "11111111-1111-1111-1111-111111111113";
            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PatchEvaluation(evaluation, this.SampleEvaluation) as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }

        [Fact]
        public void Test_patch_evaluation_invalid_hasEditDate_returns_status_BadRequest()
        {
            this.SampleEvaluation.EditDate = DateTime.Now;
            var evaluation = "11111111-1111-1111-1111-111111111113";
            var expected = StatusCodes.Status400BadRequest;
            var actual = this.Controller.PatchEvaluation(evaluation, this.SampleEvaluation) as IStatusCodeActionResult;
            Assert.Equal(expected, actual.StatusCode);
        }
    }
}