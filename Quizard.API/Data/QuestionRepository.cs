using System.Collections.Generic;
using System.Threading.Tasks;
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


        public async Task<List<Question>> GetQuestions(QuestionParams questionParams)
        {
            var questions = await _context.Questions.Include(a => a.QuestionsCategories)
                                              .ThenInclude(questionCategory => questionCategory.Category)
                                              .OrderByDescending(q => q.CreatedDate).ToListAsync();
            return questions;
        }


        public async Task<Question> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(a => a.Answers).FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public async Task AddQuestionCategory(int id, int cat)
        {
            var category = _context.Categories.Find(cat);
            var question = _context.Questions.FirstOrDefault(a => a.Id == id);
            QuestionCategory newQuestCat = new QuestionCategory { Category = category, Question = question };
            await _context.Set<QuestionCategory>().AddAsync(newQuestCat);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
