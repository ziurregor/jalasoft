namespace Jalasoft.Eva.Evaluations.Api.Rest.Controllers
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Api.Rest.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    [ApiController]
    public class EvaluationsController : AbstractController
    {
        [HttpPost]
        [Route("api/v1/evaluations")]
        public ActionResult<Evaluation> PostEvaluation([FromBody]Evaluation evaluation)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var createdEvaluation = ServicesFacade.Instance.GetEvaluationsService().CreateEvaluation(evaluation);
                    Log.Info(string.Format("Evaluation {0} created", createdEvaluation.Name));
                    return createdEvaluation;
                },
                StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("api/v1/evaluations")]
        public ActionResult<IList<Evaluation>> GetEvaluations()
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    StringValues pageSize = string.Empty;
                    StringValues pageNumber = string.Empty;
                    StringValues sortValue = string.Empty;
                    StringValues matchValue = string.Empty;

                    var sortCriteria = new SortCriteria();

                    if (!this.TryGetQueryParam("page[size]", out pageSize))
                    {
                        throw new HttpException(StatusCodes.Status400BadRequest, "Page size is required");
                    }

                    if (!this.TryGetQueryParam("page[number]", out pageNumber))
                    {
                        throw new HttpException(StatusCodes.Status400BadRequest, "Page number is required");
                    }

                    if (this.TryGetQueryParam("sort", out sortValue))
                    {
                        sortCriteria.SortOption = SortOption.Ascendent;
                        if (sortValue.ToString().StartsWith("-"))
                        {
                            sortValue = sortValue.ToString().Replace("-", string.Empty);
                            sortCriteria.SortOption = SortOption.Descendent;
                        }

                        sortCriteria.Property = sortValue;
                    }

                    this.TryGetQueryParam("filter", out matchValue);

                    var queryParam = new QueryParameters()
                    {
                        SortCriteria = sortCriteria,
                        SearchCriteria = new SearchCriteria() { Property = "Name", MatchInput = matchValue },
                        PageNumber = int.Parse(pageNumber),
                        PageSize = int.Parse(pageSize)
                    };

                    var evaluations = ServicesFacade.Instance.GetEvaluationsService().GetEvaluations(queryParam);
                    Log.Info(string.Format("Found {0} evaluations", evaluations.Data.Count));
                    return evaluations;
                },
                StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("api/v1/evaluations/{id}")]
        public ActionResult<Evaluation> GetEvaluation(string id)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", idGuid));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for evaluation");
                    }

                    var evaluation = ServicesFacade.Instance.GetEvaluationsService().GetEvaluation(idGuid);
                    Log.Info(string.Format("Evaluation {0} retrieved", evaluation.Name));
                    return evaluation;
                },
                StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Route("api/v1/evaluations/{id}")]
        public ActionResult DeleteEvaluation(string id)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", idGuid));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for evaluation");
                    }

                    Log.Info(string.Format("Deleting the evaluation with id {0}", id));
                    ServicesFacade.Instance.GetEvaluationsService().DeleteEvaluation(idGuid);
                },
                StatusCodes.Status204NoContent);
        }

        [HttpPatch]
        [Route("api/v1/evaluations/{id}")]
        public ActionResult PatchEvaluation(string id, [FromBody] Evaluation evaluation)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    if (!Guid.TryParse(id, out Guid idGuid))
                    {
                        Log.Info(string.Format("Could not convert {0} to Guid", idGuid));
                        throw new HttpException(StatusCodes.Status400BadRequest, "Invalid Id request, please enter a valid GUID for evaluation");
                    }

                    Log.Info(string.Format("Updating the evaluation with id {0}", id));
                    evaluation.Id = idGuid;
                    ServicesFacade.Instance.GetEvaluationsService().UpdateEvaluation(evaluation);
                },
                StatusCodes.Status204NoContent);
        }
    }
}
