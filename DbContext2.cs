using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.Models;

namespace TestProject.Core.Context
{
    public class DbContext<T> : IDBMethods<T>
    {
        private MongoDatabase database;
        private MongoCollection<T> collection;
        public DbContext()
        {
            GetDatabase();
            GetCollection();
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
        public void Add(T entity)
        {
            collection.Insert(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
