using AutoMapper;
using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Catalog.DTOs.CategoryDTOs;
using Casgem_Microservice.Catalog.Models;
using Casgem_Microservice.Catalog.Settings.Abstracts;
using MongoDB.Driver;

namespace Casgem_Microservice.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly IDatabaseSettings _databaseSettings;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
            return Response<CreateCategoryDto>.Success(_mapper.Map<CreateCategoryDto>(value), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var value = await _categoryCollection.DeleteOneAsync(x=>x.CategoryId == id);
            if (value.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Silinecek kategori bulunamadı.", 404);
        }

        public async Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultCategoryDto>.Fail("Böyle bir ID bulunamadı.", 404);
            }
            return Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(value), 200);
        }

        public async Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values), 200);
        }

        public async Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, value);
            if (result == null)
            {
                return Response<UpdateCategoryDto>.Fail("Güncellenmek için veri bulunamadı.", 404);
            }
            return Response<UpdateCategoryDto>.Success(204);
        }
    }
}