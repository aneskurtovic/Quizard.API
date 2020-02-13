using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionRepository _repo;
        private readonly IMapper _mapper;

        public SessionsController(ISessionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSessionDto sessionDto)
        {
            var session = _mapper.Map<Session>(sessionDto);
            await _repo.AddSession(session);
            return Ok(new ResponseSessionDto {Id = session.Id, QuizId = session.QuizId });
        }
        [HttpPost("Finish")]
        public async Task<IActionResult> Finish([FromBody]FinishSessionDto result)
        {
            ResponseFinishSessionDto sessionResult = await _repo.GetResult(result.QuizResult);
            return Ok(sessionResult);
        }
    }
}