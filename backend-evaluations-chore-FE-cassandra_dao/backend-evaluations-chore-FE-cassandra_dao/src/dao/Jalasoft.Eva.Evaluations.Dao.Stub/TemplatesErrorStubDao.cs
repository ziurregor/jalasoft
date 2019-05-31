namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public class TemplatesErrorStubDao : ITemplatesDao, IDaoBuilder<ITemplatesDao>
    {
        public ITemplatesDao Create()
        {
            return new TemplatesErrorStubDao();
        }

        public Template CreateTemplate(Template template)
        {
            throw new NotImplementedException();
        }

        public Template GetTemplate(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Template> GetTemplates()
        {
            throw new NotImplementedException();
        }

        public void UpdateTemplate(Template template)
        {
            throw new ItemNotFoundDaoException($"Couldn't find template with id {template.Id}");
        }

        bool ITemplatesDao.DeleteTemplate(Guid id)
        {
            throw new ItemNotFoundDaoException(string.Format("Unable to find a register with id {0}", id));
        }
    }
}
