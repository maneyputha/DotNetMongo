using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entitities.Interfaces
{
    public interface IBaseContext<T>
    {
        //Create
        Object Create(Object entity);
        // Read
        Task<T> Get(ObjectId objectId);
        Task<IEnumerable<T>> Get();
        // Update
        Task<bool> Update(ObjectId objectId, T entity);
        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
