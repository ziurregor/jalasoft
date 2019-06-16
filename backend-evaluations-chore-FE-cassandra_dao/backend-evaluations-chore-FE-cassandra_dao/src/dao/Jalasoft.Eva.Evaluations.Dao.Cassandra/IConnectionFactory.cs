namespace Jalasoft.Eva.Evaluations.Dao.Cassandra
{
    using System;
    using global::Cassandra;
    using global::Cassandra.Mapping;

    public interface IConnectionFactory
    {
        ISession Session { get; }

        IMapper GetMapper(ISession session);
    }
}
