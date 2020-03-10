using Quizard.API.Dtos;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ISessionRepository
    {
        Task AddSession(Session session);
        Task<List<Session>> GetTop10(int quizId);
        Task<Session> GetSession(string id);
        Task<List<Question>> GetQuestionsForQuiz(int quizId);
        Task<List<int>> GetCorrectAnswersForQuestion(int questionId);
        Task FinishSession(string sessionId, int result);
    }
}
