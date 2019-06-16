namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Dao;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public sealed class TemplatesService : AbstractService, ITemplatesService, IRegistrableFactory<ITemplatesService>
    {
        private IDaoBuilder<ITemplatesDao> templateDaoBuilder;

        public TemplatesService()
        {
        }

        public TemplatesService(IDaoBuilder<ITemplatesDao> daoBuilder)
        {
            this.templateDaoBuilder = daoBuilder;
        }

        public ITemplatesService CreateInstance()
        {
            var daoBuiler = new TemplatesStubDao();
            return new TemplatesService(daoBuiler);
        }

        public IList<Template> GetTemplates()
        {
            return ServiceErrorHandler.Handle(() =>
            {
                var dao = this.templateDaoBuilder.Create();
                var templatelist = dao.GetTemplates();
                Log.Info(string.Format("Found {0} templates", templatelist.Count));
                return templatelist;
            });
        }

        public void DeleteTemplate(Guid id)
        {
            ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Attempting to delete Template with ID: {0}", id));
                var dao = this.templateDaoBuilder.Create();
                dao.DeleteTemplate(id);
            });
        }

        public Template CreateTemplate(Template template)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info("Creating the Template");
                ITemplatesDao dao = this.templateDaoBuilder.Create();
                Template newTemplate = dao.CreateTemplate(template);

                return newTemplate;
            });
        }

        public Template GetTemplate(Guid id)
        {
            return ServiceErrorHandler.Handle(() =>
            {
                var dao = this.templateDaoBuilder.Create();
                var template = dao.GetTemplate(id);
                Log.Info(string.Format("Template found with id: {0}", template.Id));
                return template;
            });
        }

        public void UpdateTemplate(Template template)
        {
            ServiceErrorHandler.Handle(() =>
            {
                Log.Info(string.Format("Attemping to update template with ID {0}", template.Id));
                var dao = this.templateDaoBuilder.Create();
                dao.UpdateTemplate(template);
            });
        }
    }
}
