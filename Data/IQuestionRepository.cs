using System.Collections.Generic;
using System.Threading.Tasks;
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public interface IQuestionRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);

    }
}