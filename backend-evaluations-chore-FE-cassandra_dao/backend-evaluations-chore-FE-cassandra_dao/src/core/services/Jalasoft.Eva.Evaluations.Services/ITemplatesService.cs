namespace Jalasoft.Eva.Evaluations.Services
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public interface ITemplatesService
    {
        Template CreateTemplate(Template template);

        void DeleteTemplate(Guid id);

        Template GetTemplate(Guid id);

        IList<Template> GetTemplates();

        void UpdateTemplate(Template template);
    }
}
