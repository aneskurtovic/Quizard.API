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

        public async Task<ResponseFinishSessionDto> GetResult(Dictionary<int, int[]> answeredQuestions, int quizId, string sessionId)
        {
            int correctQuestionsCounter = 0;
            double totalNumberOfAnsweredQuestions = answeredQuestions.Count();

            if (totalNumberOfAnsweredQuestions == 0)
            {
                return new ResponseFinishSessionDto { Result = 0, CorrectQuestions = getAllCorrectAnswers(quizId) };
            }

            var questions = _context.Questions.Include(x => x.QuizzesQuestions).ThenInclude(x => x.Quiz).Where(x => x.QuizzesQuestions.Any(y => y.QuizId == quizId)).ToList();
            double totalNumberOfQuestions = questions.Count();

            foreach (var question in questions)
            {
                var correctAnswersCounter = 0;
                var correctAnswersIds = _context.Answers.Where(a => a.QuestionId == question.Id && a.IsCorrect == true).Select(b => b.Id);

                if (!answeredQuestions.ContainsKey(question.Id) || answeredQuestions[question.Id] == null || answeredQuestions[question.Id].Length == 0)
                {
                    continue;
                }

                if (correctAnswersIds.Count() == answeredQuestions[question.Id].Length)
                {
                    correctAnswersCounter = GetCountOfCorrectAnswers(correctAnswersIds, answeredQuestions[question.Id], 0);
                }

                if (correctAnswersCounter == correctAnswersIds.Count())
                {
                    correctQuestionsCounter++;
                }
            }

            var session = _context.Sessions.Find(Guid.Parse(sessionId));
            session.FinishedAt = DateTime.Now;
            var result = (int)Math.Round((correctQuestionsCounter / totalNumberOfQuestions) * 100, 0);
            session.Result = result;
            await _context.SaveChangesAsync();

            return totalNumberOfAnsweredQuestions != 0 ?
                new ResponseFinishSessionDto { Result = result, CorrectQuestions = getAllCorrectAnswers(quizId) } :
                new ResponseFinishSessionDto { Result = 0, CorrectQuestions = getAllCorrectAnswers(quizId) };
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
        private Dictionary<int, int[]> getAllCorrectAnswers(int quizId)
        {
            var correctAnswers = new Dictionary<int, int[]>();
            var questions = _context.Questions.Include(x => x.QuizzesQuestions).ThenInclude(x => x.Quiz).Where(x => x.QuizzesQuestions.Any(y => y.QuizId == quizId)).ToList();
            foreach (var question in questions)
            {
                List<int> answers = _context.Answers.Where(x => x.QuestionId == question.Id && x.IsCorrect == true).Select(x => x.Id).ToList();
                var correctAnswerss = answers.ToArray();
                correctAnswers.Add(question.Id, correctAnswerss);
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

        public async Task<List<Session>> GetTop10(int quizId)
        {
            var neki = await _context.Sessions.Where(x => x.QuizId == quizId).OrderByDescending(x => x.Result).ToListAsync();
            return neki;
        }
    }
}
