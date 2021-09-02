using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Example.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }//MongoDb üretecek
        public string Name { get; set; }
    }
}
