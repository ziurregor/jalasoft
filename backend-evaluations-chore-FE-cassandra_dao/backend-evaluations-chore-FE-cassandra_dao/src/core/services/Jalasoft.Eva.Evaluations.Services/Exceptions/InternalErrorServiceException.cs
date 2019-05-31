namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using System;

    public class InternalErrorServiceException : ServiceException
    {
        public InternalErrorServiceException(string message)
            : base(message)
        {
        }

        public InternalErrorServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
