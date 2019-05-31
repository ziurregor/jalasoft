namespace Jalasoft.Eva.Evaluations.Dao.Exceptions
{
    using System;

    public class InternalErrorDaoException : DaoException
    {
        public InternalErrorDaoException(string message)
            : base(message)
        {
        }

        public InternalErrorDaoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
