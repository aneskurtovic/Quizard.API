using Microsoft.EntityFrameworkCore;
using Quizard.API.Dtos;
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
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();   
        }

        public async Task<SessionResultDto> GetResult(Dictionary<int, int> answeredQuestions)
        {
            double brojacTacnih = 0;
            double result;
            double ukupanBroj = answeredQuestions.Count();
            Dictionary<int, int> correctAnswers = new Dictionary<int, int>();
            foreach (var question in answeredQuestions)
            {
                int correctAnswerId = _context.Answers.Where(a => a.QuestionId == question.Key && a.IsCorrect == true).FirstOrDefaultAsync().Id;
                if (correctAnswerId == question.Value)
                {
                    brojacTacnih++;
                }
               correctAnswers.Add(question.Key, correctAnswerId);   
            }
            if (ukupanBroj == 0)
            {
                result = 0;
            }
            else {  
                result = (brojacTacnih / ukupanBroj) * 100;
            }
            return new SessionResultDto { Result = result, CorrectQuestions = correctAnswers };
        }
    }
}
