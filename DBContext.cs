using Entitities.Models;
using Microsoft.Extensions.Configuration;

namespace Entitities
{
    public class DBContext
    {
        private static DBContext context;

        public AbstractContext<Car> car ;

        public DBContext()
        {
            if(context == null)
            {
                car = new AbstractContext<Car>();

                Context = this;
            }
        }

        public static DBContext Context { get => context; set => context = value; }
    }
}
