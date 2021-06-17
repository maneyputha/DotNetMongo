using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Models
{
    public interface IDBMethods<T>
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
