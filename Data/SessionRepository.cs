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

        public async Task<ResponseFinishSessionDto> GetResult(Dictionary<int, int[]> answeredQuestions)
        {
            int correctQuestionsCounter = 0;
            double totalNumberOfQuestions = answeredQuestions.Count();

            foreach (var answeredQuestion in answeredQuestions)
            {
                var correctAnswersCounter = 0;
                var correctAnswersIds = _context.Answers.Where(a => a.QuestionId == answeredQuestion.Key && a.IsCorrect == true).Select(b => b.Id); 
                
                if (correctAnswersIds.Count() == answeredQuestion.Value.Count())
                {
                    correctAnswersCounter = GetCountOfCorrectAnswers(correctAnswersIds, answeredQuestion.Value, 0);
                }

                if (correctAnswersCounter == correctAnswersIds.Count())
                {
                    correctQuestionsCounter++;  
                }
            }

            return totalNumberOfQuestions != 0 ? 
                new ResponseFinishSessionDto { Result = Math.Round((correctQuestionsCounter / totalNumberOfQuestions) * 100, 0), CorrectQuestions = getAllCorrectAnswers(answeredQuestions) } : 
                new ResponseFinishSessionDto { Result = 0, CorrectQuestions = getAllCorrectAnswers(answeredQuestions) };
        }

        private bool isCorrectAnswered(int correctAnswer, int[] selectedAnswers)
        {
            foreach (var selectedAnswer in selectedAnswers)
            {
                if (selectedAnswer == correctAnswer)
                {
                    return true;
                }
            }
            return false;
        }
        private Dictionary<int, int[]> getAllCorrectAnswers (Dictionary<int, int[]> selectedQuestions)
        {
            var correctAnswers = new Dictionary<int, int[]>();
            foreach (var selectedQuestion in selectedQuestions)
            {
                IQueryable<int> correctAnswersIds = _context.Answers.Where(a => a.QuestionId == selectedQuestion.Key && a.IsCorrect == true).Select(b => b.Id);
                var correctAnswersArray = correctAnswersIds.ToArray();

                correctAnswers.Add(selectedQuestion.Key, correctAnswersArray);
            }
            return correctAnswers;
        }

        private int GetCountOfCorrectAnswers(IQueryable<int> correctAnswersIds, int[] answeredQuestion, int counter)
        {
            foreach (var correctAnswer in correctAnswersIds)
            {
                if (isCorrectAnswered(correctAnswer, answeredQuestion))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
