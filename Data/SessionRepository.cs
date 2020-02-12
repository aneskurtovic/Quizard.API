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
            double ukupanBroj = answeredQuestions.Count();
            Dictionary<int, bool> correctAnswers = new Dictionary<int, bool>();
            foreach (var question in answeredQuestions)
            {
                int questionId = question.Key;
                int answerId = question.Value;
                int correctAnswerId =  _context.Answers.Where(a => a.QuestionId == questionId && a.IsCorrect == true).FirstOrDefault().Id;
                if (correctAnswerId == answerId) {
                    correctAnswers.Add(questionId, true);
                    brojacTacnih++;
                }
                else
                {
                   correctAnswers.Add(questionId, false);
                }
            }
            double result;
            if (ukupanBroj == 0)
            {
                result = 0;
            }
            else {  
                result = (brojacTacnih / ukupanBroj) * 100;
            }
            SessionResultDto dto = new SessionResultDto { Result = result, CorrectQuestions = correctAnswers };
            return dto;
        }
    }
}
