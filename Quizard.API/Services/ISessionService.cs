using Quizard.API.Dtos;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public interface ISessionService
    {
        Task<List<GetSessionForLeaderboardDto>> GetTop10(int id);
        Task<GetSessionDto> GetSession(string id);
        Task<ResponseSessionDto> AddSession(CreateSessionDto sessionDto);
        Task<ResponseFinishSessionDto> GetResult(FinishSessionDto result);
    }
}
