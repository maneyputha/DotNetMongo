using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entitities.Interfaces
{
    /// <summary>
    ///    Generic Interface Base Context. 
    ///    Consist the abstractions of the key methods required for the ORM
    ///    Created By - Manendra Ranathunga
    ///    Created Date - 15.06.2021
    /// </summary>
    public interface IBaseContext<T>
    {
        // Collection
        IMongoCollection<T> Collection();
        //Create
        Object Create(Object entity);
        // Read
        T Get(ObjectId objectId);
        IEnumerable<T> Get();
        // Update
        T Update(ObjectId objectId, T entity);
        // Delete
        bool Delete(ObjectId objectId);
    }
}
