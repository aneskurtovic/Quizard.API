using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSession(Session session)
        {
            session.Id = Guid.NewGuid();
            session.StartedAt = DateTime.Now;
            var quiz = _context.Quizzes.Find(session.QuizId);
            session.FinishedAt = session.StartedAt.AddMinutes(quiz.Timer);
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task<Session> GetSession(string id)
        {
            return await _context.Sessions.Include(x => x.Quiz)
                                            .ThenInclude(x=>x.QuizzesQuestions)
                                            .ThenInclude(x=>x.Question)
                                            .ThenInclude(x=>x.Answers)
                                            .Where(x => x.Id == Guid.Parse(id))
                                            .FirstOrDefaultAsync();
        }

        public async Task FinishSession(string sessionId, int result)
        {
            var session = _context.Sessions.Find(Guid.Parse(sessionId));
            session.FinishedAt = DateTime.Now;
            session.Result = result;

            await _context.SaveChangesAsync();           
        }

        public async Task<List<Session>> GetTop10(int quizId)
        {
            return await _context.Sessions.Where(x => x.QuizId == quizId).OrderByDescending(x => x.Result).Take(10).ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsForQuiz(int quizId)
        {
            return await _context.Questions.Include(x => x.QuizzesQuestions)
                                            .ThenInclude(x => x.Quiz)
                                            .Where(x => x.QuizzesQuestions.Any(y => y.QuizId == quizId))
                                            .ToListAsync();
        }

        public async Task<List<int>> GetCorrectAnswersForQuestion(int questionId)
        {
            return await _context.Answers.Where(a => a.QuestionId == questionId && a.IsCorrect == true)
                                            .Select(b => b.Id)
                                            .ToListAsync();
        }
    }
}