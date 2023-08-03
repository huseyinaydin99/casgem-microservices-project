using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Catalog.DTOs.CategoryDTOs;

namespace Casgem_Microservice.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        public Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}