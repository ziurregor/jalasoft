using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITodos<T>
    {
        T Get(int id);
        IEnumerable<T> GetList();
        IEnumerable<T> GetList(Func<T, bool> predicate);
        T Add(T entity);
        T Edit(T entity);
        void Remove(int id);



    }
}
