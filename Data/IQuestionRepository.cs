using System.Collections.Generic;
using System.Threading.Tasks;
<<<<<<< HEAD
using Quizard.API.Helpers;
=======
>>>>>>> Quizard5-AnesEdiCategory
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public interface IQuestionRepository
    {
        Task AddQuestion<T>(T entity) where T : class;
        Task<bool> SaveAll();
<<<<<<< HEAD
        Task<PagedList<Question>> GetQuestions(QuestionParams questionParams);
        Task<Question> GetQuestion(int id);

=======
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        void AddQuestionCategory(int id, int cat);

        int GetQuestionIDByText(string text);
>>>>>>> Quizard5-AnesEdiCategory
    }
}