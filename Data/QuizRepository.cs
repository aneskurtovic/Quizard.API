using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
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

        public async Task AddQuizQuestion(int newQuizId, int questionId)
        {
            var question = _context.Questions.FirstOrDefault(a => a.Id == questionId);
            var quiz = _context.Quizzes.FirstOrDefault(a => a.Id == newQuizId);
            var newQuizQuest = new QuizQuestion { Question = question, Quiz = quiz, QuestionId = questionId, QuizId = newQuizId };
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

        public async Task<Quiz> GetQuiz(int id)
        {
            var requestedQuiz = await _context.Quizzes.FindAsync(id);
            return requestedQuiz;
        }
    }
}

