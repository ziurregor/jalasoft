namespace Jalasoft.Eva.Evaluations.Api.Rest.Controllers
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Api.Rest.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class TemplatesController : AbstractController
    {
        [HttpPost]
        [Route("api/v1/templates")]
        public ActionResult<Template> PostTemplate(Template template)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var resultTemplate = ServicesFacade.Instance.GetTemplatesService().CreateTemplate(template);
                    Log.Info(string.Format("Template {0} created", resultTemplate.Name));
                    return resultTemplate;
                },
                StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("api/v1/templates")]
        public ActionResult<IList<Template>> GetTemplates()
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var templates = ServicesFacade.Instance.GetTemplatesService().GetTemplates();
                    Log.Info(string.Format("Found {0} templates", templates.Count));
                    return templates;
                },
                StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("api/v1/templates/{id}")]
        public ActionResult<Template> GetTemplate(string id)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", id));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for template");
                    }

                    var template = ServicesFacade.Instance.GetTemplatesService().GetTemplate(idGuid);
                    Log.Info(string.Format("Template {0} retrieved", template.Name));
                    Log.Info($"Template {template.Name} retrieved");
                    return template;
                },
                StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Route("api/v1/templates/{id}")]
        public ActionResult DeleteTemplate(string id)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", id));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for template");
                    }

                    Log.Info($"Deleting the template with id {id}");
                    ServicesFacade.Instance.GetTemplatesService().DeleteTemplate(idGuid);
                },
                StatusCodes.Status204NoContent);
        }

        [HttpPatch]
        [Route("api/v1/templates/{id}")]
        public ActionResult PatchTemplate(string id, [FromBody] Template template)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", id));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for template");
                    }

                    template.Id = idGuid;
                    Log.Info(string.Format("Updating the template with Id {0}", template.Id));
                    ServicesFacade.Instance.GetTemplatesService().UpdateTemplate(template);
                },
                StatusCodes.Status204NoContent);
        }
    }
}
