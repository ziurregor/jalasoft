namespace Jalasoft.Eva.Evaluations.Dao
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public interface ITemplatesDao
    {
        IList<Template> GetTemplates();

        bool DeleteTemplate(Guid id);

        Template CreateTemplate(Template template);

        Template GetTemplate(Guid id);

        void UpdateTemplate(Template template);
    }
}
