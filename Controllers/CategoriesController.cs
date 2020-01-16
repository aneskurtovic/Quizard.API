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

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await repo.GetCategories();
            var categoriesToReturn = mapper.Map<List<CategoryForGet>>(categories);
            return Ok(categoriesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryForPost categoryDto)
        {
            var category =  mapper.Map<Category>(categoryDto);

            repo.Add(category);

            if (await repo.SaveAll())
                return Ok(category.Id);
            else
                return BadRequest();
        }

    }
}
