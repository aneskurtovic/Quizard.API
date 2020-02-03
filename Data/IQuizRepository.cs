using Quizard.API.Models;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuiz(string name, int[] questionIds);
        Task<int> GetQuizIdByName(string name);
        Task<bool> SaveAll();
        Task AddQuizQuestion(int newQuizId, int question);
        Task<Quiz> GetQuiz(int id);
    }
}
