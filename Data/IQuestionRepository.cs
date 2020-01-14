using System.Collections.Generic;
using System.Threading.Tasks;
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public interface IQuestionRepository
    {
        Task AddQuestion<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        void AddQuestionCategory(int id, int cat);

        int GetQuestionIDByText(string text);
    }
}