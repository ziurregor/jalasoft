namespace Jalasoft.Eva.Evaluations.Api.Rest.Controllers
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class AnswersController : AbstractController
    {
        [HttpGet]
        [Route("api/v1/evaluations/{idEvaluation}/answers/{idAnswer}")]
        public ActionResult<EvaluationScore> GetAnswer(Guid idAnswer)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var answers = ServicesFacade.Instance.GetAnswersService().GetAnswer(idAnswer);
                    Log.Info(string.Format("Answers for evaluation {0} retrieved", answers.IdEvaluation));
                    return answers;
                },
                StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("api/v1/evaluations/{idEvaluation}/answers")]
        public ActionResult<IList<EvaluationScore>> GetAnswers(Guid idEvaluation)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var answers = ServicesFacade.Instance.GetAnswersService().GetAnswers(idEvaluation);
                    Log.Info(string.Format("List of answers for evaluation {0} retrieved", idEvaluation));
                    return answers;
                },
                StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("api/v1/evaluations/{idEvaluation}/answers")]
        public ActionResult<EvaluationScore> PostAnswers(Guid idEvaluation, [FromBody]EvaluationAnswer answersList)
        {
            return this.ExecuteRequestAndHandle(
                () =>
                {
                    var newAnswers = ServicesFacade.Instance.GetAnswersService().CreateAnswers(idEvaluation, answersList);
                    Log.Info(string.Format("Answers for evaluation {0} created", idEvaluation));
                    return newAnswers;
                },
                StatusCodes.Status201Created);
        }
    }
}