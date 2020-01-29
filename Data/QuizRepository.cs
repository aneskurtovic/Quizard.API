using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddQuiz<T>(T entity) where T : class
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddQuizQuestion(int newQuizId, int questionId)
        {
            var question = _context.Questions.FirstOrDefault(a => a.Id == questionId);
            var quiz = _context.Quizzes.FirstOrDefault(a => a.Id == newQuizId);
            QuizQuestion newQuizQuest = new QuizQuestion { Question = question, Quiz = quiz };
            await _context.Set<QuizQuestion>().AddAsync(newQuizQuest);
        }

        public async Task<int> GetQuizIdByName(string name)
        {
            var Quiz = await _context.Quizzes.FirstOrDefaultAsync(a => a.Name == name);
            return Quiz.Id;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

