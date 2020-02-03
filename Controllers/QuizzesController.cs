using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizRepository _repo;
        private readonly IMapper _mapper;

        public QuizzesController(IQuizRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuizToPostDto quizDto)
        {
            Quiz quiz = _mapper.Map<Quiz>(quizDto);
            int[] questionIds = quizDto.QuestionIds;
            var responseQuiz = await _repo.AddQuiz(quiz, questionIds);
            var newQuizResponse = new QuizForResponseDto { Id = responseQuiz.Id };
            return Ok(newQuizResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _repo.GetQuiz(id);
            var quizToReturn = _mapper.Map<QuizForGetDto>(quiz);
            return Ok(quizToReturn);
        }
    }
}