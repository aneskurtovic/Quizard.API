using Microsoft.AspNetCore.Mvc;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Services;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {

        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateQuizDto quizDto)
        {
            var responseQuiz = await _quizService.AddQuiz(quizDto);
            return Ok(new ResponseQuizDto { Id = responseQuiz.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizzes([FromQuery]QuestionParams questionParams)
        {
           return Ok(await _quizService.GetQuizzes(questionParams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)    
        {      
            return Ok(await _quizService.GetQuiz(id));
        }

        [HttpGet("Leaderboard")]
        public async Task<IActionResult> GetLeaderboard()
        {
            return Ok(await _quizService.GetLeaderboard());       
        }
    }
}
