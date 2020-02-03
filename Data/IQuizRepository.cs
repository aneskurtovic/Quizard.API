using Quizard.API.Dtos;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuiz(Quiz quiz, int [] questionIds);
        Task<int> GetQuizIdByName(string name);
        Task<bool> SaveAll();
        Task AddQuizQuestion(int newQuizId, int question);
    }
}
