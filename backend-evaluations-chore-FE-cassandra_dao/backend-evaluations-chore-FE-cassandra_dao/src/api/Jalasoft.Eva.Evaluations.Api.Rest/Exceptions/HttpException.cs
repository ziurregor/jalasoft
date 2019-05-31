namespace Jalasoft.Eva.Evaluations.Api.Rest.Exceptions
{
    using System;
    using System.Net;

    public class HttpException : Exception
    {
        public HttpException(int errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public HttpException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }
    }
}