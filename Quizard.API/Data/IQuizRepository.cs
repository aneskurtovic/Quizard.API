using Quizard.API.Helpers;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuiz(string name, int[] questionIds, int Timer);
        Task<Quiz> GetQuiz(int id);
        Task<List<Quiz>> GetQuizzes(QuestionParams questionParams);
        Task<List<Quiz>> GetQuizzesLeaderboard();
    }
}
