using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(quizDto.Timer < 1)
            {
                throw new Exception("Timer cannot be less than 1");
            }
       
            if (quizDto.QuestionIds.Length < 1) 
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
            return _mapper.Map<GetQuizDto>(await _repo.GetQuiz(id));
        }

        public async Task<PagedResult<GetQuizForListDto>> GetQuizzes(QuestionParams questionParams)
        {
            var quizzes = await _repo.GetQuizzes(questionParams);
            var quizzesDtos = _mapper.Map<IEnumerable<GetQuizForListDto>>(quizzes.Data);
            var results = new PagedResult<GetQuizForListDto>(quizzesDtos, quizzes.Metadata.Total, quizzes.Metadata.Offset, quizzes.Metadata.PageSize);
            return results;

        }
    }
}
