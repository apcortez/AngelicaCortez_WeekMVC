using System;
using System.Collections.Generic;

namespace Week14Day5.Core
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
