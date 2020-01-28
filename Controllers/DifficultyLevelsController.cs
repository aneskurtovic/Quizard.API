using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyLevelsController : ControllerBase
    {
        private readonly IDifficultyLevelRepository _repo;
        private readonly IMapper _mapper;

        public DifficultyLevelsController(IDifficultyLevelRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDifficultyLevel()
        {
            var levels = await _repo.GetDifficultyLevels();
            var levelsToReturn = _mapper.Map<IEnumerable<DifficultyLevelForListDto>>(levels);
            return Ok(levelsToReturn);
        }
    }
}