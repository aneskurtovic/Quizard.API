using Quizard.API.Dtos;
using System.Collections.Generic;

namespace Quizard.Tests.Builders
{
    class CreateFinishSessionDtoBuilder
    {
        private Dictionary<int, int[]> _quizResult = new Dictionary<int, int[]> { };
        private int _quizId;
        private string _sessionId;

        public FinishSessionDto Build()
        {
            return new FinishSessionDto() {QuizResult=_quizResult, QuizId = _quizId ,SessionId=_sessionId };
        }
        
        public CreateFinishSessionDtoBuilder BuildQuizId(int Id)
        {
            _quizId = Id;
            return this;
        }

        public CreateFinishSessionDtoBuilder BuildSessionId(string Id)
        {
            _sessionId = Id;
            return this;
        }
    }
}
