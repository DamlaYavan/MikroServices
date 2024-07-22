using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<ProductImage> _productimageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            var _productimageCollection = database.GetCollection<ProductImage>(databaseSetting.ProductImageCollectionName);
            _mapper = mapper;
        }


        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _productimageCollection.InsertOneAsync(values);

        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productimageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productimageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value =  _productimageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productimageCollection.FindOneAndReplaceAsync(x=>x.ProductImageId==updateProductImageDto.ProductImageId,value);

        }
    }
}
