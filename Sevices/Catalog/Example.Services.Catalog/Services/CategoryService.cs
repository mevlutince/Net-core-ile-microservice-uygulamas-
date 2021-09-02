using AutoMapper;
using Example.Services.Catalog.Dtos;
using Example.Services.Catalog.Models;
using Example.Services.Catalog.Settings;
using Example.Shared.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Catalog.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);//startuptan geliyor
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GeteAllAsync(){
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }
    
        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }
    
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            
        }
    }
}
