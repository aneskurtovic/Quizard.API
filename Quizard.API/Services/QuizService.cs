using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repo;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Quiz> AddQuiz(CreateQuizDto quizDto)
        {
            if (string.IsNullOrWhiteSpace(quizDto.Name))
            {
                throw new Exception("Quiz name cannot be empty name");
            }
            if(quizDto.Timer < 1)
            {
                throw new Exception("Timer cannot be less than 1");
            }
       
            if (quizDto.QuestionIds == null ||  quizDto.QuestionIds.Length < 1) 
            {
                throw new Exception("You must have at least one question.");
            }
            var responseQuiz = await _repo.AddQuiz(
                quizDto.Name,
                quizDto.QuestionIds,
                quizDto.Timer
            );
            return responseQuiz;
        }

        public async Task<List<GetQuizForLeaderboardDto>> GetLeaderboard()
        {
            return _mapper.Map<List<GetQuizForLeaderboardDto>>(await _repo.GetQuizzesLeaderboard());
        }

        public async Task<GetQuizDto> GetQuiz(int id)
        {
            if (id <= 0)
            {
                throw new Exception("QuizID must be higher than 0");
            }

            return _mapper.Map<GetQuizDto>(await _repo.GetQuiz(id));
        }

        public async Task<PagedResult<GetQuizForListDto>> GetQuizzes(QuestionParams questionParams)
        {
            var quizzes = await _repo.GetQuizzes(questionParams);
            var count = quizzes.Count();
            var data = quizzes.Skip(questionParams.Offset * questionParams.PageSize).Take(questionParams.PageSize).ToList();
            var pagedQuiz = new PagedResult<Quiz>(data, count, questionParams.Offset, questionParams.PageSize);
            var quizzesDtos = _mapper.Map<IEnumerable<GetQuizForListDto>>(pagedQuiz.Data);
            var results = new PagedResult<GetQuizForListDto>(quizzesDtos, pagedQuiz.Metadata.Total, pagedQuiz.Metadata.Offset, pagedQuiz.Metadata.PageSize);
            return results;
        }
    }
}
