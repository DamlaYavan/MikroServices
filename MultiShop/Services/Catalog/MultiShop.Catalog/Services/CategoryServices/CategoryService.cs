using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
        
    {
        //readonly anahtar kelimesi, bu alanın sadece sınıfın kurucusu (constructor) içinde ayarlanabileceğini ve sonrasında
        //değiştirilemeyeceğini belirtir.

        private readonly IMongoCollection<Category> _categoryCollection; //mongodb deki category koleksiyonuna(tablosuna)  erişim sağlamak için field türetme
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings) //constructor metodu
        {   //3 aşama var bir bağlantı iki veritabanı 3 tablo
            var client =new MongoClient(_databaseSettings.ConnectionString); //connectionstring ile  erişim için  bağlantı oluşturduk
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veritabanını ( adı ile )  alıyoruz
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);  // kategori tablosunu aldık.
            _mapper = mapper;
        }

        public async Task CreatCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value =_mapper.Map<Category>(createCategoryDto); // mapleme (eşleme) createcategoryDto ile category maplenir
            await _categoryCollection.InsertOneAsync(value); //mongodbde ekleme işlemi
            //await asenkron yapı 
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(x=>x.CategoryId== id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoyAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoyAsync(string id)
        {
            var values= await _categoryCollection.Find<Category>(x=>x.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values); //mongodbde güncelleme metodu FindOneAndReplace


        }
    }
}
