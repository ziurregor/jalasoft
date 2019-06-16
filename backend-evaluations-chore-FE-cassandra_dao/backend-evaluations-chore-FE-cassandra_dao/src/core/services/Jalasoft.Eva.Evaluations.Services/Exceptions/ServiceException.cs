namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using System;

    public abstract class ServiceException
        : Exception
    {
        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
