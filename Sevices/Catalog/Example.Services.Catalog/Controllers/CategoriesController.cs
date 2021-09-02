using Example.Services.Catalog.Dtos;
using Example.Services.Catalog.Services;
using Example.Shared.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GeteAllAsync();
            return CreateActionResultInstance(categories);
        }
    

        // categoris/5 şeklinde bir url yazdıgımızda bu metot çalışacak
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var categories = await _categoryService.CreateAsync(categoryDto);
            return CreateActionResultInstance(categories);
        }


    }
}
