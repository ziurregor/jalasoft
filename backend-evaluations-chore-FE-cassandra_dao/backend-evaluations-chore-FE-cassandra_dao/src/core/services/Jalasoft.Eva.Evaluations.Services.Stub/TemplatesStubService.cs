namespace Jalasoft.Eva.Evaluations.Services.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public class TemplatesStubService : ITemplatesService, IRegistrableFactory<ITemplatesService>
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(TemplatesStubService));

        public ITemplatesService CreateInstance()
        {
            return new TemplatesStubService();
        }

        public IList<Template> GetTemplates()
        {
            List<Template> storage = new List<Template>();
            storage = new List<Template>();
            storage.Add(new Template()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Technical Template",
                ScoreFormula = "sum(i, 0, questionsLength, questionScore(i))"
            });

            storage.Add(new Template()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Name = "Psychotechnical Template",
                ScoreFormula = "sum(i, 0, questionsLength, questionScore(i))"
            });

            return storage;
        }

        public void DeleteTemplate(Guid id)
        {
            Log.Info(string.Format("The template {0} is being removed", id));
        }

        public Template CreateTemplate(Template template)
        {
            return template;
        }

        public Template GetTemplate(Guid id)
        {
            return new Template
            {
                Id = id,
                Name = "Test template",
                ScoreFormula = "sum(i, 0, questionsLength, questionScore(i))"
            };
        }

        public void UpdateTemplate(Template template)
        {
            Log.Info(string.Format("Template {0} is being updated", template.Id));
            return;
        }
    }
}