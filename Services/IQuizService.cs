using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public interface IQuizService
    {
        Task<Quiz> AddQuiz(CreateQuizDto quizDto);
        Task<PagedResult<GetQuizForListDto>> GetQuizzes(QuestionParams questionParams);
        Task<GetQuizDto> GetQuiz(int id);
        Task<List<GetQuizForLeaderboardDto>> GetLeaderboard();

    }
}
