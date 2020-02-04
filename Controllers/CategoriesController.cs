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
            var categoriesToReturn = _mapper.Map<List<GetCategoryDto>>(await _repo.GetCategories(searchTerm));
            return Ok(categoriesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryToPostDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var existingCat = await _repo.CategoryExists(categoryDto.Name);
            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetCategoryDto>(existingCat);
                return Ok(existingCategoryForGetDto);
            }
            await _repo.AddCategory(category);
            var categoryForGetDto = _mapper.Map<GetCategoryDto>(category);
            return Ok(categoryForGetDto);
        }
    }
}
