    using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using Quizard.API.Services;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
           _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions([FromQuery]QuestionParams questionParams)
        {
            return Ok(await _questionService.GetQuestions(questionParams));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateQuestionDto questionDto)
        {
                return Ok(await _questionService.AddQuestionAndCategory(questionDto));
        }
    }
}