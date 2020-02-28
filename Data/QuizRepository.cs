﻿using Microsoft.EntityFrameworkCore;
using Quizard.API.Helpers;
using Quizard.API.Models;
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

        public async Task<Quiz> AddQuiz(string name, int[] questionIds)
        {
            var quizForInsert = new Quiz
            {
                Name = name,
                QuizzesQuestions = questionIds.Select(x => new QuizQuestion { QuestionId = x }).ToList()
            };
            await _context.AddAsync(quizForInsert);
            await _context.SaveChangesAsync();
            return quizForInsert;
        }

        public async Task<Quiz> GetQuiz(int id)
        {
            var requestedQuiz = await _context.Quizzes.Include(a => a.QuizzesQuestions).ThenInclude(b => b.Question).ThenInclude(b => b.Answers).FirstOrDefaultAsync(c => c.Id == id);
            return requestedQuiz;
        }
        public async Task<PagedResult<Quiz>> GetQuizzes(QuestionParams questionParams)
        {
            var quizzez = await _context.Quizzes.Include(x=>x.QuizzesQuestions).ToListAsync();
            var count =  quizzez.Count();
            var data =  quizzez.Skip(questionParams.Offset * questionParams.PageSize).Take(questionParams.PageSize).ToList();
            return new PagedResult<Quiz>(data, count, questionParams.Offset, questionParams.PageSize);
        }
    }
}

