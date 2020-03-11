﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
            var levelsToReturn = _mapper.Map<IEnumerable<GetDifficultyLevelDto>>(await _repo.GetDifficultyLevels());
            return Ok(levelsToReturn);
        }
    }
}