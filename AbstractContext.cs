using Entitities.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entitities
{
    public class AbstractContext<T>: IBaseContext<T> where T : class
    {
        IMongoCollection<T> collection; 

        public AbstractContext(IMongoDatabase database)
        {
            collection = database.GetCollection<T>(nameof(T));
        }

        private void GetDatabase()
        {
            var client = new MongoClient("ConnectionString");
            MongoServer server = client.GetServer();

            database = server.GetDatabase("");
        }
        private void GetCollection()
        {
            collection = database
            .GetCollection<T>(typeof(T).Name);
        }



        public Object Create(Object entity)
        {
            collection.InsertOneAsync((T)entity).Wait(); ;
            return (T)entity;
        }

        public Task<bool> Delete(ObjectId objectId)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(ObjectId objectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ObjectId objectId, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
