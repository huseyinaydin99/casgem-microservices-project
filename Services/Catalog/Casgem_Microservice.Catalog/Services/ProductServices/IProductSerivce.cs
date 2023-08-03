using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Catalog.DTOs.ProductDTOs;

namespace Casgem_Microservice.Catalog.Services.ProductServices
{
    public interface IProductSerivce
    {
        Task<Response<List<ResultProductDto>>> GetProductListAsync();
        Task<Response<ResultProductDto>> GetProductByIdAsync(string id);
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<Response<UpdateProductDto>> UpdateCategoryAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<ResultProductDto>>> GetProductListWithAsync();
    }
}