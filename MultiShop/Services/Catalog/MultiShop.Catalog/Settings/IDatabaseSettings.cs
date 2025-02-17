﻿namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        //Bağlantı işlemimizi gerçekleştiricek 

        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
