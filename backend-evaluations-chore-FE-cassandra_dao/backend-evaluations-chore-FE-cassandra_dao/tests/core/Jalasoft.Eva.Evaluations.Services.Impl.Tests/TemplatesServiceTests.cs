namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Xunit;

    public class TemplatesServiceTests
    {
        [Fact]
        public void TestGetTemplates()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var actual = service.GetTemplates();

            Assert.NotNull(actual);
        }

        [Fact]

        public void TestGetTemplate()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var actual = service.GetTemplate(new Guid("11111111-1111-1111-1111-111111111112"));

            Assert.NotNull(actual);
        }

        [Fact]
        public void TestRemoveTemplate()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            service.DeleteTemplate(Guid.Parse("11111111-1111-1111-1111-111111111112"));
        }

        [Fact]
        public void TestPostTemplates()
        {
            var expected = new Template()
            {
                Name = "New EvaluationTemplate"
            };

            var service = new TemplatesService(new TemplatesStubDao());
            var actual = service.CreateTemplate(expected);

            Assert.True(expected.Name == actual.Name);
        }

        [Fact]
        public void TestUpdateTemplate_Succesful_Update()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var stubTemplates = service.GetTemplates();
            var actual = stubTemplates[0];
            var expected = new Template { Id = actual.Id, Name = "Updated name" };

            service.UpdateTemplate(expected);

            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void TestUpdateTemplate_Throws_ItemNotFoundException()
        {
            var service = new TemplatesService(new TemplatesErrorStubDao());
            var expected = new Template { Id = Guid.NewGuid(), Name = "Updated name" };

            Assert.Throws<ItemNotFoundServiceException>(() => { service.UpdateTemplate(expected); });
        }

        [Fact]
        public void TestUpdateTemplate_ItemNotFoundException_Message()
        {
            var service = new TemplatesService(new TemplatesErrorStubDao());
            var expected = new Template { Id = Guid.NewGuid(), Name = "Updated name" };
            var origMessage = $"Couldn't find template with id {expected.Id}";

            try
            {
                service.UpdateTemplate(expected);
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, origMessage);
            }
        }

        [Fact]
        public void TestRemoveNonExistingTemplate_Throws_ItemNotFoundException_Message()
        {
            var expected = "Unable to find a template with id f480b496-2356-402b-9fdc-a1893cc64e16";
            try
            {
                var service = new TemplatesService(new TemplatesStubDao());
                service.DeleteTemplate(Guid.Parse("f480b496-2356-402b-9fdc-a1893cc64e16"));
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestGetTemplate_OnlySingleChoiceM2O_Template()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var template = service.GetTemplate(new Guid("11111111-1111-1111-1111-111111111113"));

            Assert.Single(template.Body);
        }

        [Fact]
        public void TestGetTemplate_SingleChoiceWeightedIdM2O_Template()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var template = service.GetTemplate(new Guid("11111111-1111-1111-1111-111111111113"));
            QuestionField question = template.Body[0];
            Assert.Equal(question.Id, new Guid("5f4df704-8201-4e4f-94c2-4409da82bdb9"));
        }

        [Fact]
        public void TestGetTemplate_M2O_HasHeader()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var template = service.GetTemplate(new Guid("11111111-1111-1111-1111-111111111113"));
            Assert.NotEmpty(template.Headers);
        }

        [Fact]
        public void TestGetTemplate_M2O_HasHeaderTextField()
        {
            var service = new TemplatesService(new TemplatesStubDao());
            var template = service.GetTemplate(new Guid("11111111-1111-1111-1111-111111111113"));
            DataField text = template.Headers[0];
            Assert.Equal(text.Id, new Guid("36004a67-4c36-4457-a30f-617ca9e0c838"));
        }
    }
}