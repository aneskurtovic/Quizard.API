using Quizard.API.Dtos;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ISessionRepository
    {
        Task AddSession(Session session);
        Task<ResponseFinishSessionDto> GetResult(Dictionary<int, int> answeredQuestions);
    }
}
