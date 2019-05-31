namespace Jalasoft.Eva.Evaluations.Api.Rest.Controllers
{
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class HealthController : AbstractController
    {
        [HttpGet]
        [Route("api/v1/health")]
        public ActionResult<ApplicationHealthInfo> GetHealth()
        {
            return this.ExecuteRequestAndHandle(
                () => ServicesFacade.Instance.GetHealthService().GetServiceHealth(),
                StatusCodes.Status200OK);
        }
    }
}
