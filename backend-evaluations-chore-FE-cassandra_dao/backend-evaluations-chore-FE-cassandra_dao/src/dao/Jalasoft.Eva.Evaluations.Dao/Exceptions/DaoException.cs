namespace Jalasoft.Eva.Evaluations.Dao.Exceptions
{
    using System;

    public abstract class DaoException : Exception
    {
        public DaoException(string message)
            : base(message)
        {
        }

        public DaoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
