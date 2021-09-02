using Example.Services.Catalog.Dtos;
using Example.Services.Catalog.Models;
using Example.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Catalog.Services
{
    public interface ICategoryService
    {
        public Task<Response<List<CategoryDto>>> GeteAllAsync();
        public Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        public Task<Response<CategoryDto>> GetByIdAsync(string id);        

    }
}
