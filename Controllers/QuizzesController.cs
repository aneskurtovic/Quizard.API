using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
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
        public async Task<IActionResult> Post([FromBody]QuizToPostDto quizDto)
        {
            var responseQuiz = await _repo.AddQuiz(
                quizDto.Name,
                quizDto.QuestionIds
            );
            return Ok(new QuizForResponseDto { Id = responseQuiz.Id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quizToReturn = _mapper.Map<GetQuizDto>(await _repo.GetQuiz(id));
            return Ok(quizToReturn);
        }
    }
}