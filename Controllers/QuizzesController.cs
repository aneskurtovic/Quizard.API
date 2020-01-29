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
            var quiz = _mapper.Map<Quiz>(quizDto);
            await _repo.AddQuiz(quiz);
            await _repo.SaveAll();
            int newQuizId = await _repo.GetQuizIdByName(quiz.Name);
            foreach (var question in quizDto.Questions)
            {
                _repo.AddQuizQuestion(newQuizId, question);
            }

            await _repo.SaveAll();
            string url = "/api/quizzes/" + newQuizId;
            return Ok(url);
        }
    }
}