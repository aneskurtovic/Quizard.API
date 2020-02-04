using Quizard.API.Models;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuiz(string name, int[] questionIds);
        Task<Quiz> GetQuiz(int id);
    }
}
