namespace Jalasoft.Eva.Evaluations.Dao.Cassandra
{
    using System;
    using global::Cassandra;
    using global::Cassandra.Mapping;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;

    public abstract class AbstractCassandraDao
    {
        protected IConnectionFactory connection;

        public AbstractCassandraDao(IConnectionFactory connection)
        {
            this.connection = connection;
        }

        public T ExecuteQuery<T>(Func<ISession, T> queryDelegate)
        {
            using (var session = this.connection.Session)
            {
                var result = queryDelegate.Invoke(session);
                return result;
            }
        }

        public T Execute<T>(Func<IMapper, T> queryDelegate)
        {
            using (var session = this.connection.Session)
            {
                try
                {
                    IMapper mapper = this.connection.GetMapper(session);
                    var result = queryDelegate.Invoke(mapper);
                    return result;
                }
                catch (DriverException e)
                {
                    throw this.ProcessException(e);
                }
            }
        }

        private Exception ProcessException(Exception ex)
        {
            if (ex is DaoException)
            {
                return (DaoException)ex;
            }

            return new InternalErrorDaoException("There is a problem with the DAO operation", ex);
        }
    }
}
