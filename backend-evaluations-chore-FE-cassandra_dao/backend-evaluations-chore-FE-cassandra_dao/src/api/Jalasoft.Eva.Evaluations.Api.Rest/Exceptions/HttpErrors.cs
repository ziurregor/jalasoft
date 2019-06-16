namespace Jalasoft.Eva.Evaluations.Api.Rest.Exceptions
{
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Api.Rest.Model;

    public class HttpErrors
    {
        public HttpErrors()
        {
            this.Errors = new List<HttpErrorMessage>();
        }

        public List<HttpErrorMessage> Errors { get; set; }
    }
}
