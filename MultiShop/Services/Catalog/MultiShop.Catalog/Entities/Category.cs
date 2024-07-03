using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]  //MongoDb de GUidler bu şekilde tanımlanıyor
        [BsonRepresentation(BsonType.ObjectId)]
         public string CategoryId { get; set; }

        public int MyProperty { get; set; }
    }
}
