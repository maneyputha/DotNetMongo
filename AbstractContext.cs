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

        public AbstractContext()
        {
            GetDatabase();
        }

        private void GetDatabase()
        {
            var client = new MongoClient(AppSettings.GetSettingValue("ConnectionStrings", "MongoDb"));
            var database = client.GetDatabase(AppSettings.GetSettingValue("ConnectionStrings", "DatabaseName"));
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection()
        {
            return collection;
        }

        public Object Create(Object entity)
        {
            collection.InsertOneAsync((T)entity).Wait(); ;
            return (T)entity;
        }

        public bool Delete(ObjectId objectId)
        {
            var result = collection.DeleteOne($"{{ _id: ObjectId('{objectId}') }}");
            return result.DeletedCount == 1;
        }

        public T GetById(ObjectId objectId)
        {
            return collection.Find($"{{ _id: ObjectId('{objectId}') }}").FirstOrDefault();
        }

        public IEnumerable<T> Get()
        {
            return collection.Find(_ => true).ToList();
        }

        public Task<bool> Update(ObjectId objectId, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
