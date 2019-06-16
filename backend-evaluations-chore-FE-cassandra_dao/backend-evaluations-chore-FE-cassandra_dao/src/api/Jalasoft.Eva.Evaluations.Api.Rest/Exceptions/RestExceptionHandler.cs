namespace Jalasoft.Eva.Evaluations.Api.Rest.Exceptions
{
    using System.Net;
    using Jalasoft.Eva.Core.ExceptionHandler;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Microsoft.AspNetCore.Http;

    public class RestExceptionHandler : AbstractExceptionHandler<HttpException>
    {
        public RestExceptionHandler()
            : base()
        {
            this.Catch<InternalErrorServiceException>(ex =>
            {
                var httpErrorMessage = "Internal error, contact your administrator";
                return new HttpException(StatusCodes.Status500InternalServerError, httpErrorMessage);
            })
            .Catch<ItemNotFoundServiceException>(ex => new HttpException(StatusCodes.Status404NotFound, ex.Message, ex))
            .Catch<InvalidItemServiceException>(ex => new HttpException(StatusCodes.Status400BadRequest, ex.Message, ex))
            .Catch<ValidationErrorServiceException>(ex => new HttpException(StatusCodes.Status400BadRequest, ex.Message, ex));
        }
    }
}
