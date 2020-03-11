using Quizard.API.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizard.Tests.Builders
{
    public class CreateQuizDtoBuilder
    {
        private string _name;
        private int[] _questionIds = new int[] { };
        private int _timer;

        public CreateQuizDto Build()
        {
            return new CreateQuizDto() { Name = _name, QuestionIds = _questionIds, Timer = _timer };
        }
        public CreateQuizDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CreateQuizDtoBuilder WithQuestionIds(int[] questionIds)
        {
            _questionIds = questionIds;
            return this;
        }

        public CreateQuizDtoBuilder WithTimer(int timer)
        {
            _timer = timer;
            return this;
        }
    }
}
