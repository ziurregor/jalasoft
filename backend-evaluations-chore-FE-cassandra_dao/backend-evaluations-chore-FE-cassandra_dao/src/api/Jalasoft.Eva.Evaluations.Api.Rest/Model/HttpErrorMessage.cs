namespace Jalasoft.Eva.Evaluations.Api.Rest.Model
{
    using System;
    using Jalasoft.Eva.Evaluations.Api.Rest.Exceptions;

    public class HttpErrorMessage
    {
        public HttpErrorMessage(string detail)
        {
            this.Id = Guid.NewGuid();
            this.Detail = detail;
        }

        public Guid Id { get; private set; }

        public string Detail { get; set; }

        public static HttpErrorMessage BuildFromDetail(string detail)
        {
            return new HttpErrorMessage(detail);
        }

        public static HttpErrorMessage BuildFromHttpException(HttpException httpEx)
        {
            return new HttpErrorMessage(httpEx.Message);
        }
    }
}
