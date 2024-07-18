using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService

        //Asenkron metotlar : eş zamanlı çalışan, hızlı 
    {
        Task<List<ResultCategoryDto>> GetAllCategoyAsync();
        Task CreatCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoyAsync(string id);

    }
}
