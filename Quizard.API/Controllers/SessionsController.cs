using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using Quizard.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("{id}/leaderboard")]
        public async Task<IActionResult> GetTop10(int id)
        {
            return Ok(await _sessionService.GetTop10(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSession(string id)
        {
            return Ok(await _sessionService.GetSession(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSessionDto sessionDto)
        {
            return Ok(await _sessionService.AddSession(sessionDto));
        }

        [HttpPost("Finish")]
        public async Task<IActionResult> Finish([FromBody]FinishSessionDto result)
        {
            return Ok(await _sessionService.GetResult(result));
        }
    }
}
