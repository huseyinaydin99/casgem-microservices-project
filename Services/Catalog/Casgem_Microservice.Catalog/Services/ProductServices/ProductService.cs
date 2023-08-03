using AutoMapper;
using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Catalog.DTOs.ProductDTOs;
using Casgem_Microservice.Catalog.Models;
using Casgem_Microservice.Catalog.Settings.Abstracts;
using MongoDB.Driver;

namespace Casgem_Microservice.Catalog.Services.ProductServices
{
    public class ProductService : IProductSerivce
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
            return Response<CreateProductDto>.Success(_mapper.Map<CreateProductDto>(values), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var value = await _productCollection.DeleteOneAsync(id);
            if(value.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Silinecek ürün verisi bulunamadı.", 404);
        }

        public async Task<Response<ResultProductDto>> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultProductDto>.Fail("Böyle bir ID bulunamadı.", 404);
            }
            return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(value), 200);
        }

        public async Task<Response<List<ResultProductDto>>> GetProductListAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<List<ResultProductDto>>> GetProductListWithAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            if (values.Any())
            {
                foreach (var item in values)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstOrDefaultAsync();
                }
            }
            else
            {
                values = new List<Product>();
            }
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<UpdateProductDto>> UpdateCategoryAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
            if (result == null)
            {
                return Response<UpdateProductDto>.Fail("Güncellenmek için veri bulunamadı.", 404);
            }
            return Response<UpdateProductDto>.Success(204);
        }
    }
}