namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using System;

    public class InvalidItemServiceException : ServiceException
    {
        public InvalidItemServiceException(string message)
            : base(message)
        {
        }

        public InvalidItemServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
