using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //Mongodbde böyle tutuluyor id ler string ve özel 
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
