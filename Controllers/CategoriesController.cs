using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository repo;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories([FromQuery]string searchTerm)
        {
            var categories = await repo.GetCategories(searchTerm);
            var categoriesToReturn = mapper.Map<List<CategoryForGetDto>>(categories);
            return Ok(categoriesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryForPostDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            var existingCat = await repo.CategoryExists(categoryDto.Name);
            if (existingCat != null)
            {
                var existingCategoryForGetDto = mapper.Map<CategoryForGetDto>(existingCat);
                return Ok(existingCategoryForGetDto);
            }
            await repo.AddCategory(category);
            await repo.SaveAll();
            var categoryForGetDto = mapper.Map<CategoryForGetDto>(category);
            return Ok(categoryForGetDto);
        }

    }
}
