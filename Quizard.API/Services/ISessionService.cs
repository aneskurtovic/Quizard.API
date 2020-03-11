using Quizard.API.Dtos;
using System.Collections.Generic;
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
