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


        public async Task<PagedResult<Question>> GetQuestions(QuestionParams questionParams)
        {
            IQueryable<Question> questions = _context.Questions.Include(a => a.QuestionsCategories)
                                              .ThenInclude(questionCategory => questionCategory.Category)
                                              .OrderByDescending(q => q.CreatedDate);


            questions = SearchByName(questions, questionParams.Name);

            questions = FilterByCategory(questions, questionParams.Category, questionParams.Operand);


            var count = await questions.CountAsync();
            var data = await questions.Skip(questionParams.Offset * questionParams.PageSize).Take(questionParams.PageSize).ToListAsync();


            return new PagedResult<Question>(data, count, questionParams.Offset, questionParams.PageSize);

        }

        private IQueryable<Question> SearchByName(IQueryable<Question> questions, string questionName)
        {
            if (string.IsNullOrWhiteSpace(questionName))
                return questions;

            return questions.Where(o => o.Text.ToLower().Contains(questionName.Trim().ToLower()));
        }

        private IQueryable<Question> FilterByCategory(IQueryable<Question> questions, IList<int> categoriesnest, CategoryOperand? operand)
        {
            if (categoriesnest.Count == 0 || !operand.HasValue)
                return questions;


            if (operand == CategoryOperand.Or)
            {
                questions = questions.Where(c => c.QuestionsCategories.Any(y => categoriesnest.Contains(y.CategoryID)));
            }
            else if (operand == CategoryOperand.And)
            {
                questions = questions.Where(q => q.QuestionsCategories.All(qc => categoriesnest.Contains(qc.CategoryID))
                                                  && q.QuestionsCategories.Count == categoriesnest.Count);
            }

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
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
