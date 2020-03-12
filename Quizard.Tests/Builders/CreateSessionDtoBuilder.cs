using Quizard.API.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizard.Tests.Builders
{
    class CreateSessionDtoBuilder
    {
            private string _contestantName;
            private int _quizId;

            public CreateSessionDto Build()
            {
                return new CreateSessionDto() { ContestantName= _contestantName, QuizId= _quizId};
            }
            public CreateSessionDtoBuilder BuildContestantName(string name)
            {
                _contestantName = name;
                return this;
            }

            public CreateSessionDtoBuilder BuildQuizId(int Id)
            {
                _quizId = Id;
                return this;
            }


    }
}
