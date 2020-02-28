using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Post([FromBody]CreateQuizDto quizDto)
        {
            var responseQuiz = await _repo.AddQuiz(
                quizDto.Name,
                quizDto.QuestionIds
            );
            return Ok(new ResponseQuizDto { Id = responseQuiz.Id });
        }
        [HttpGet]
        public async Task<IActionResult> GetQuizzez([FromQuery]QuestionParams questionParams)
        {
            var quizzes = await _repo.GetQuizzes(questionParams);
            var quizzesdtos = _mapper.Map<IEnumerable<GetQuizForListDto>>(quizzes.Data);
            var results = new PagedResult<GetQuizForListDto>(quizzesdtos, quizzes.Metadata.Total, quizzes.Metadata.Offset, quizzes.Metadata.PageSize);
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quizToReturn = _mapper.Map<GetQuizDto>(await _repo.GetQuiz(id));
            return Ok(quizToReturn);
        }
    }
}