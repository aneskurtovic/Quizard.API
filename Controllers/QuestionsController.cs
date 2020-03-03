    using System.Collections.Generic;
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
            var questionDtos = _mapper.Map<IEnumerable<GetQuestionForListDto>>(questions.Data);
            var results = new PagedResult<GetQuestionForListDto>(questionDtos, questions.Metadata.Total, questions.Metadata.Offset, questions.Metadata.PageSize);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            if(_repo.MinimumOneCorrect(question))
            {
                return BadRequest();
            }
            await _repo.AddQuestion(question);
            foreach (var category in questionDto.Categories)
            {
                await _repo.AddQuestionCategory(question.Id, category);
            }
            if (await _repo.SaveAll())
            {
                return Ok(question);
            }
            return BadRequest();
        }
    }
}