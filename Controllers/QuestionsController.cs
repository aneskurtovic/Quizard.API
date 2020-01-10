﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _repo;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _repo.GetQuestions();

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _repo.GetQuestion(id);

            var questionToReturn = _mapper.Map<QuestionForDetailedListDto>(question);

            return Ok(questionToReturn);
        }

        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]QuestionForPostDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto); //maping object from QuestionForPostDto into question

            _repo.Add(question);

            if (await _repo.SaveAll())
            {
                return Ok(question);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionForPostDto model)
        {
            var question = _repo.GetQuestion(id);
            if (question == null)
            {
                return NotFound();
            }
            
            await _mapper.Map(model, question);

            if (await _repo.SaveAll())
            {
                return Ok(_mapper.Map<QuestionForPostDto>(question));
            }

            return BadRequest();
        }
    }
}