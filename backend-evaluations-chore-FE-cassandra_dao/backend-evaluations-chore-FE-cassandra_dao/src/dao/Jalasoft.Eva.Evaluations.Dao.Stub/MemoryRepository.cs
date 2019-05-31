namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain;

    public class MemoryRepository<T> : IRepository<T>
        where T : Entity
    {
        public MemoryRepository()
        {
            this.List = new List<T>();
        }

        public List<T> List { get; set; }

        public T Get(Guid id)
        {
            var obj = default(T);
            obj = this.List.Find(item => item.Id == id);
            return obj;
        }

        public bool Remove(Guid id)
        {
            var obj = this.List.Find(item => item.Id == id);
            return this.List.Remove(obj);
        }
    }
}