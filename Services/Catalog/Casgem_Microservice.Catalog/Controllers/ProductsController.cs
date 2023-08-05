using Casgem_Microservice.Catalog.DTOs.ProductDTOs;
using Casgem_Microservice.Catalog.Models;
using Casgem_Microservice.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem_Microservice.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var values = await (_productService.GetProductListAsync());
            return Ok(values);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var Product = await _productService.GetProductByIdAsync(id);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok(updateProductDto);
        }
    }
}