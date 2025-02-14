﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {

        [BsonId]  //MongoDb de GUidler bu şekilde tanımlanıyor
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }

        [BsonIgnore]  //özelliğin MongoDb de kaydedilmesini engeller. 
        public Product Product { get; set; }
    }
}
