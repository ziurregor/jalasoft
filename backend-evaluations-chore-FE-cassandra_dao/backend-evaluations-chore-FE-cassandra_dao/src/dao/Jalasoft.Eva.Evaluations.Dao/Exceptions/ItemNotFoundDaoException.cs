namespace Jalasoft.Eva.Evaluations.Dao.Exceptions
{
    using System;

    public class ItemNotFoundDaoException : Exception
    {
        public ItemNotFoundDaoException(string message)
            : base(message)
        {
        }

        public ItemNotFoundDaoException(string message, Exception innerException)
             : base(message, innerException)
        {
        }
    }
}