namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using System;

    public class ValidationErrorServiceException : ServiceException
    {
        public ValidationErrorServiceException(string message)
            : base(message)
        {
        }

        public ValidationErrorServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
