using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Catalog.DTOs.CategoryDTOs;

namespace Casgem_Microservice.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync();
        Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id);
        Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}