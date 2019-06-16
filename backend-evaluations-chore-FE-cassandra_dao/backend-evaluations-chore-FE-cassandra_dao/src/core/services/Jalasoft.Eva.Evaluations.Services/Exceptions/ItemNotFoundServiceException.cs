namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using System;

    public class ItemNotFoundServiceException : ServiceException
    {
        public ItemNotFoundServiceException(string message)
            : base(message)
        {
        }

        public ItemNotFoundServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
