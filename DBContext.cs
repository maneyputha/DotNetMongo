using Entitities.Interfaces;
using Entitities.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitities
{
    public class DBContext
    {
        private static DBContext dbContext;

        public AbstractContext<Car> car ;

        public DBContext(IMongoClient client, IConfiguration config)
        {
            if(DbContext == null)
            {
                var database = client.GetDatabase(config.GetConnectionString("DatabaseName"));
                car = new AbstractContext<Car>(database);

                dbContext = this;
            }
        }

        public static DBContext DbContext { get => dbContext; }
    }
}
