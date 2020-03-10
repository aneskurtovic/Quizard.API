using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionAndCategory(CreateQuestionDto question);
        Task<PagedResult<GetQuestionForListDto>> GetQuestions(QuestionParams questionParams);
    }
}
