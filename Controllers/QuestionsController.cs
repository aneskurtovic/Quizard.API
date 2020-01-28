﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
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
        public async Task<IActionResult> GetQuestions([FromQuery]QuestionParams questionParams)
        {
            var questions = await _repo.GetQuestions(questionParams);

            var questionsToReturn = _mapper.Map<IEnumerable<QuestionForListDto>>(questions);


            Response.AddPagination(questions.CurrentPage, questions.PageSize, questions.TotalCount, questions.TotalPages);

            return Ok(questionsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _repo.GetQuestion(id);

            var questionToReturn = _mapper.Map<QuestionForDetailedListDto>(question);

            return Ok(questionToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuestionToPostDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            await _repo.AddQuestion(question);

            var questionId = _repo.GetQuestionIdByText(question.Text);

            foreach (var cat in questionDto.Categories)
            {
                _repo.AddQuestionCategory(questionId, cat);
            }

            if (await _repo.SaveAll())
            {
                return Ok(question);
            }

            return BadRequest();
        }

    }
}