namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using Jalasoft.Eva.Evaluations.Domain;

    public interface IRepository<T>
        where T : Entity
    {
        T Get(Guid id);

        bool Remove(Guid id);
    }
}