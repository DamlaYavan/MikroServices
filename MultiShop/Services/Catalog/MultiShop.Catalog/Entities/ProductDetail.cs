using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]  //MongoDb de GUidler bu şekilde tanımlanıyor
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }

        public string ProductLongDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
