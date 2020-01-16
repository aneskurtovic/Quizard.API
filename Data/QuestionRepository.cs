﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quizard.API.Helpers;
using System.Linq;
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestion<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<Question>> GetQuestions(QuestionParams questionParams)
        {
            var questions = _context.Questions.Include(a => a.Answers);

            return await PagedList<Question>.CreateAsync(questions, questionParams.PageNumber, questionParams.PageSize);
        }

        public async Task<Question> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(a => a.Answers).FirstOrDefaultAsync(q => q.Id == id);

            return question;
        }

        public async void AddQuestionCategory(int id, int cat)
        {
            var category = _context.Categories.Find(cat);
            var question = _context.Questions.FirstOrDefault(a => a.Id == id);
            QuestionCategory newQuestCat = new QuestionCategory { Category = category, Question= question};
            await _context.Set<QuestionCategory>().AddAsync(newQuestCat);
        }

        public int GetQuestionIDByText(string text)
        {
            var questionID = _context.Questions.FirstOrDefault(a => a.Text == text).Id;
            return questionID;
        }
    }
}
