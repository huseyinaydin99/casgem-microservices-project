using MongoDB.Bson.Serialization.Attributes;

namespace Casgem_Microservice.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //otomatik guid bir değer vermesi içindir!
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}