using AutoMapper;
using Casgem_Microservice.Catalog.DTOs.CategoryDTOs;
using Casgem_Microservice.Catalog.DTOs.ProductDTOs;
using Casgem_Microservice.Catalog.Models;

namespace Casgem_Microservice.Catalog.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}