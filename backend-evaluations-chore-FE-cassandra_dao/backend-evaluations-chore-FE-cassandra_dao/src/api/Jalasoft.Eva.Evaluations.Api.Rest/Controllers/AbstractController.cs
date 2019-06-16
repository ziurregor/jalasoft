namespace Jalasoft.Eva.Evaluations.Api.Rest.Controllers
{
    using System;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Api.Rest.Exceptions;
    using Jalasoft.Eva.Evaluations.Api.Rest.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    [ApiController]
    public abstract class AbstractController : ControllerBase
    {
        protected static readonly ILogger Log = LoggerFactory.GetLogger(typeof(HealthController));
        private static readonly RestExceptionHandler RestErrorHandler = new RestExceptionHandler();

        protected delegate T ExecuteRequest<T>();

        protected delegate void ExecuteRequest();

        protected ActionResult ExecuteRequestAndHandle<T>(ExecuteRequest<T> executeRequest, int responseCode)
        {
            try
            {
                return RestErrorHandler.Handle(() =>
                {
                    Log.Info(string.Format("Entering {0} method", executeRequest.Method));
                    T result = executeRequest.Invoke();
                    var response = this.StatusCode(responseCode, result);
                    Log.Info(string.Format("Leaving {0} method", executeRequest.Method));
                    return response;
                });
            }
            catch (Exception ex)
            {
                return this.ProcessException(ex);
            }
        }

        protected ActionResult ExecuteRequestAndHandle(ExecuteRequest executeRequest, int responseCode)
        {
            try
            {
                return RestErrorHandler.Handle(() =>
                {
                    Log.Info(string.Format("Entering {0} method", executeRequest.Method));
                    executeRequest.Invoke();
                    var response = this.StatusCode(responseCode);
                    Log.Info(string.Format("Leaving {0} method", executeRequest.Method));
                    return response;
                });
            }
            catch (Exception ex)
            {
                return this.ProcessException(ex);
            }
        }

        protected bool TryGetQueryParam(string key, out StringValues value)
        {
            value = string.Empty;
            try
            {
                return this.Request.Query.TryGetValue(key, out value);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private ActionResult ProcessException(Exception ex)
        {
            HttpErrorMessage httpError;
            HttpErrors httpErrors = new HttpErrors();

            if (ex is HttpException)
            {
                HttpException exCasted = (HttpException)ex;
                httpError = HttpErrorMessage.BuildFromDetail(exCasted.Message);
                httpErrors.Errors.Add(httpError);
                return this.StatusCode(exCasted.ErrorCode, httpErrors);
            }

            httpError = HttpErrorMessage.BuildFromDetail("Internal error, contact your administrator");
            httpErrors.Errors.Add(httpError);
            Log.Error(string.Format("{0}: Internal error, contact your administrator, Unhandled exception {1}", httpError.Id, ex));
            return this.StatusCode(StatusCodes.Status500InternalServerError, httpErrors);
        }
    }
}