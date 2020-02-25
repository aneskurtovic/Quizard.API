﻿using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quizard.API.Helpers;
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
            await _context.SaveChangesAsync();
        }


        public async Task<PagedResult<Question>> GetQuestions(QuestionParams questionParams)
        {
            IQueryable<Question> questions = _context.Questions.Include(a => a.QuestionsCategories)
                                              .ThenInclude(questionCategory => questionCategory.Category)
                                              .OrderByDescending(q => q.CreatedDate);

            SearchByName(ref questions, questionParams.Name);

            var count = await questions.CountAsync();
            var data = await questions.Skip(questionParams.Offset * questionParams.PageSize).Take(questionParams.PageSize).ToListAsync();
            return new PagedResult<Question>(data, count, questionParams.Offset, questionParams.PageSize);
        }

        private void SearchByName(ref IQueryable<Question> questions, string questionName)
        {
            if (!questions.Any() || string.IsNullOrWhiteSpace(questionName))
                return;

            if (string.IsNullOrEmpty(questionName))
                return;
 
            questions = questions.Where(o => o.Text.ToLower().Contains(questionName.Trim().ToLower()));
        }


        public async Task<Question> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(b => b.DifficultyLevel).Include(a => a.Answers).FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }
        public async Task<bool> MinimumOneCorrect(Question question)
        {
            return question.Answers.Count(a=>a.IsCorrect==true) == 0;
        }
        public async Task AddQuestionCategory(int id, int cat)
        {
            var category = _context.Categories.Find(cat);
            var question = _context.Questions.FirstOrDefault(a => a.Id == id);
            QuestionCategory newQuestCat = new QuestionCategory { Category = category, Question = question };
            await _context.Set<QuestionCategory>().AddAsync(newQuestCat);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
