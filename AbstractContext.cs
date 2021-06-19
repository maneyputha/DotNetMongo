using Entitities.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Entitities
{
    /// <summary>
    ///    Generic class that initializes the ORM basics.
    ///    <typeparam>
    ///    T - takes in a param of type model in the runtime. 
    ///    </typeparam>
    ///    Created By - Manendra Ranathunga
    ///    Created Date - 15.06.2021
    /// </summary>
    public class AbstractContext<T>: IBaseContext<T> where T : class
    {
        IMongoCollection<T> collection; 

        public AbstractContext()
        {
            GetDatabase();
        }

        /// <summary>
        ///    Loads the database. 
        ///    Uses the connection string values from the appsetting.json
        ///    Created By - Manendra Ranathunga/ Shehan Wilfred
        ///    Created Date - 18.06.2021
        /// </summary>
        private void GetDatabase() 
        {
            var client = new MongoClient(AppSettings.GetSettingValue("ConnectionStrings", "MongoDb"));
            var database = client.GetDatabase(AppSettings.GetSettingValue("ConnectionStrings", "DatabaseName"));
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        ///    Returns the collection of the generic type
        ///    (Model) passed in during the initialization.
        ///    <returns>
        ///    Returns a Mongo collection of the Model.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 18.06.2021
        /// </summary>
        public IMongoCollection<T> Collection()
        {
            return collection;
        }

        /// <summary>
        ///    Adds a new entry to the MongoDb collection.
        ///    <param>
        ///    entity (Model Object) - Accepts a generic object (of type - model). 
        ///    </param>
        ///    <returns>
        ///    Returns an object of type model.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 16.06.2021
        /// </summary>
        public Object Create(Object entity)
        {
            collection.InsertOne((T)entity); ;
            return (T)entity;
        }

        /// <summary>
        ///    Deletes an entry from the MongoDb collection.
        ///    <param>
        ///    objectId (ObjectId) - Accepts a MongoDB ObjectId. 
        ///    </param>
        ///    <returns>
        ///    Returns an bool success or not.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 18.06.2021
        /// </summary>
        public bool Delete(ObjectId objectId)
        {
            var result = collection.DeleteOne($"{{ _id: ObjectId('{objectId}') }}");
            return result.DeletedCount == 1;
        }

        /// <summary>
        ///    Gets an object from the collection (of type model).
        ///    <param>
        ///    objectId (ObjectId) - Accepts the specific MongoDB ObjectId. 
        ///    </param>
        ///    <returns>
        ///    Returns a collection object of type Model.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 16.06.2021
        /// </summary>
        public T Get(ObjectId objectId)
        {
            return collection.Find($"{{ _id: ObjectId('{objectId}') }}").FirstOrDefault();
        }

        /// <summary>
        ///    Gets a list of collections (of type model) as an Enumerable.
        ///    <returns>
        ///    Returns a list collections of type Model.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 18.06.2021
        /// </summary>
        public IEnumerable<T> Get()
        {
            return collection.Find(_ => true).ToList();
        }

        /// <summary>
        ///    Updates a record in the collection.
        ///    <param>
        ///    objectId (ObjectId) - Accepts the specific MongoDB ObjectId. 
        ///    entity ((T)Model) - Object of type model that needs to be updated.
        ///    (requires the id(ObjectId) in the object as well.
        ///    </param>
        ///    <returns>
        ///    Returns a collection object (updated) of type Model.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 16.06.2021
        /// </summary>
        public T Update(ObjectId objectId, T entity)
        {
            return collection.FindOneAndReplace($"{{ _id: ObjectId('{objectId}') }}", entity);
        }
    }
}
