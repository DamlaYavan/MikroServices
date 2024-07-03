using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]  //MongoDb de GUidler bu şekilde tanımlanıyor
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        public string ProductName { get; set; }
        public decimal Price  { get; set; }
        public string ImageUrl  { get; set; }
        public string Description  { get; set; }
        public string CategoryId  { get; set; }

        [BsonIgnore]  //özelliğin MongoDb de kaydedilmesini engeller. 
        public Category Category  { get; set; }



    }
}
 