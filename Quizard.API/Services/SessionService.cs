using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseSessionDto> AddSession(CreateSessionDto sessionDto)
        {
            if (string.IsNullOrWhiteSpace(sessionDto.ContestantName))
            {
                throw new Exception("Contestant name cannot be empty.");
            }
            if (sessionDto.QuizId == 0)
            {
                throw new Exception("Quiz Id cannot be null.");

            }
            var session = _mapper.Map<Session>(sessionDto);
            await _sessionRepository.AddSession(session);
            return _mapper.Map<ResponseSessionDto>(session);
        }

        public async Task<GetSessionDto> GetSession(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Session Id cannot be empty.");
            }
            Session session = await _sessionRepository.GetSession(id);
            return _mapper.Map<GetSessionDto>(session);
        }

        public async Task<List<GetSessionForLeaderboardDto>> GetTop10(int id)
        {
            List<Session> leaderboard = await _sessionRepository.GetTop10(id);
            return _mapper.Map<List<GetSessionForLeaderboardDto>>(leaderboard);
        }

        public async Task<ResponseFinishSessionDto> GetResult(FinishSessionDto result)
        {
            var answeredQuestions = result.QuizResult;

            int correctQuestionsCounter = 0;
            int totalNumberOfAnsweredQuestions = answeredQuestions.Count();

            if (totalNumberOfAnsweredQuestions == 0)
            {
                return new ResponseFinishSessionDto { Result = 0, CorrectQuestions = await GetAllCorrectAnswers(result.QuizId) };
            }

            var questions = await _sessionRepository.GetQuestionsForQuiz(result.QuizId);
            int totalNumberOfQuestions = questions.Count();

            foreach (var question in questions)
            {
                var correctAnswersCounter = 0;
                var correctAnswersIds = await _sessionRepository.GetCorrectAnswersForQuestion(question.Id);

                if (!answeredQuestions.ContainsKey(question.Id) || correctAnswersIds.Count() != answeredQuestions[question.Id].Length)
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

            var quizResult = (int)Math.Round(((double)(correctQuestionsCounter) / totalNumberOfQuestions) * 100, 0);
            await _sessionRepository.FinishSession(result.SessionId, quizResult);

            return new ResponseFinishSessionDto { Result = quizResult, CorrectQuestions = await GetAllCorrectAnswers(result.QuizId) };

        }

        private bool IsCorrectAnswered(int correctAnswer, int[] selectedAnswers)
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
        private async Task<Dictionary<int, int[]>> GetAllCorrectAnswers(int quizId)
        {
            var correctAnswers = new Dictionary<int, int[]>();
            var questions = await _sessionRepository.GetQuestionsForQuiz(quizId);
            foreach (var question in questions)
            {
                List<int> answers = await _sessionRepository.GetCorrectAnswersForQuestion(question.Id);
                var correctAnswerss = answers.ToArray();
                correctAnswers.Add(question.Id, correctAnswerss);
            }
            return correctAnswers;
        }
        private int GetCountOfCorrectAnswers(List<int> correctAnswersIds, int[] answeredQuestion, int counter)
        {
            foreach (var correctAnswer in correctAnswersIds)
            {
                if (IsCorrectAnswered(correctAnswer, answeredQuestion))
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
