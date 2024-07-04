using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping:Profile //automapper sınıfı
    {
        public GeneralMapping()
        {
            //mapleme işlemi amacı: entitylerin propertyleri dtodaki propertylerle eşlicek.

            //Category mapleme 
            CreateMap<Category, ResultCategoryDto>().ReverseMap(); //ReverseMap=> tersiylede maple demek
            CreateMap<Category, CreateCategoryDto>().ReverseMap(); 
            CreateMap<Category, UpdateCategoryDto>().ReverseMap(); 
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            //Product mapleme 
            CreateMap<Product, ResultProductDto>().ReverseMap(); 
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            //ProductDetail mapleme 
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            //ProductImage mapleme 
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();


        }
    }
}
