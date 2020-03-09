using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using Quizard.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories([FromQuery]string searchTerm)
        {
            var category = await _categoryService.GetCategories(searchTerm);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCategoryDto categoryDto)
        {
            return Ok(await _categoryService.Post(categoryDto));
        }
    }
}
