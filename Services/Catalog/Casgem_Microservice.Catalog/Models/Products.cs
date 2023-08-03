using MongoDB.Bson.Serialization.Attributes;

namespace Casgem_Microservice.Catalog.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //otomatik guid bir değer vermesi içindir! guid tür veri tipi.
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)] //decimal tür veri tipi.
        public decimal Price { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore] //bu kısmı görmezden gel mongodb'e yansıtma!!!
        public Category Category { get; set; }
    }
}
