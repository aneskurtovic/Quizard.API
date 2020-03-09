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

            var session = _mapper.Map<Session>(sessionDto);
            await _sessionRepository.AddSession(session);
            return _mapper.Map<ResponseSessionDto>(session);
        }

        public async Task<ResponseFinishSessionDto> GetResult(FinishSessionDto result)
        {
            ResponseFinishSessionDto sessionResult = await _sessionRepository.GetResult(result.QuizResult,
                                                                          result.QuizId,
                                                                          result.SessionId);
            return sessionResult;
        }

        public async Task<GetSessionDto> GetSession(string id)
        {
            Session session = await _sessionRepository.GetSession(id);
            return _mapper.Map<GetSessionDto>(session);
        }

        public async Task<List<GetSessionForLeaderboardDto>> GetTop10(int id)
        {
            List<Session> leaderboard = await _sessionRepository.GetTop10(id);
            return _mapper.Map<List<GetSessionForLeaderboardDto>>(leaderboard);
        }
    }
}
