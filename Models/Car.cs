using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entitities.Models
{
    /// <summary>
    ///    Example model (Car).
    ///    Created By - Manendra Ranathunga
    ///    Created Date - 12.06.2021
    /// </summary>
    public class Car
    {
        //ObjectId - (of type - shared key)
        public ObjectId Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TopSpeed { get; set; }
    }

}
