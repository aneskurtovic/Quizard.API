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
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories([FromQuery]string searchTerm)
        {
            if (searchTerm == null)
            {
                return Ok();
            }
            var categoriesToReturn = _mapper.Map<List<CategoryForGetDto>>(await repo.GetCategories(searchTerm));
            return Ok(categoriesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryToPostDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var existingCat = await repo.CategoryExists(categoryDto.Name);
            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<CategoryForGetDto>(existingCat);
                return Ok(existingCategoryForGetDto);
            }
            await repo.AddCategory(category);
            await repo.SaveAll();
            var categoryForGetDto = _mapper.Map<CategoryForGetDto>(category);
            return Ok(categoryForGetDto);
        }

    }
}
