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
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        // url courses/5 şeklinde olacak 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        // url api/courses/getAkkByUserId/4 şeklinde olacak. yukardaki ile karişmaması için adresi açık açık veredik
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var response = await _courseService.CreateAsync(courseCreateDto);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( string id)
        {
            var response = await _courseService.DeleteeAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
