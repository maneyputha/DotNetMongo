using Entitities.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace Entitities
{
    /// <summary>
    ///    DB context class that initializes the entities.
    ///    Created By - Manendra Ranathunga
    ///    Created Date - 13.06.2021
    ///    Updated By - Manendra Ranathunga
    ///    Updated Date - 20.06.2021
    /// </summary>
    public class DBContext
    {
        private static DBContext context;

        public AbstractContext<Car> car ;

        /// <summary>
        ///    Initializes a singleton instance of all the entities.
        ///    Uses the connection string values from the appsetting.json
        ///    Created By - Manendra Ranathunga/ Shehan Wilfred
        ///    Created Date - 17.06.2021
        /// </summary>
        public DBContext()
        {
            if(context == null)
            {
                //initialize the models here.
                car = new AbstractContext<Car>();
                //add shard key if exist by adding elements to the BsonDocument. 
                car.setShardKey(new BsonDocument().Add("Id", 1));

                //sets the current instance of the DB to a static variable.
                Context = this;
            }
        }

        public static DBContext Context { get => context; set => context = value; }
    }
}
