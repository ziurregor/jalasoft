namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Dao;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public class TemplatesStubDao : ITemplatesDao, IDaoBuilder<ITemplatesDao>
    {
        public TemplatesStubDao()
        {
        }

        public ITemplatesDao Create()
        {
            return new TemplatesStubDao();
        }

        public IList<Template> GetTemplates()
        {
            return Memory.Templates.List;
        }

        public bool DeleteTemplate(Guid id)
        {
            foreach (Template item in Memory.Templates.List)
            {
                if (item.Id == id)
                {
                    return Memory.Templates.Remove(id);
                }
            }

            throw new ItemNotFoundDaoException(string.Format("Unable to find a template with id {0}", id));
        }

        public Template CreateTemplate(Template template)
        {
            template.Id = Guid.NewGuid();
            Memory.Templates.List.Add(template);
            return Memory.Templates.Get(template.Id);
        }

        public Template GetTemplate(Guid id)
        {
            return Memory.Templates.Get(id);
        }

        public void UpdateTemplate(Template template)
        {
            Template target = this.GetTemplate(template.Id);
            target.Name = template.Name;
        }
    }
}
