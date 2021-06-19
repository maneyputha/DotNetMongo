﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entitities.Interfaces
{
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
