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

        public async Task<ResponseFinishSessionDto> GetResult(Dictionary<int, int> answeredQuestions)
        {
            double correctAnswersCounter = 0;
            double result;
            Dictionary<int, int> correctAnswers = new Dictionary<int, int>();
            foreach (var question in answeredQuestions)
            {
                int correctAnswerId = _context.Answers.Where(a => a.QuestionId == question.Key && a.IsCorrect == true).FirstOrDefaultAsync().Id;
                if (correctAnswerId == question.Value)
                {
                    correctAnswersCounter++;
                }
               correctAnswers.Add(question.Key, correctAnswerId);   
            }
            if (answeredQuestions.Count() == 0)
            {
                result = 0;
            }
            else {  
                result = (correctAnswersCounter / answeredQuestions.Count()) * 100;
            }
            return new ResponseFinishSessionDto { Result = result, CorrectQuestions = correctAnswers };
        }
    }
}
