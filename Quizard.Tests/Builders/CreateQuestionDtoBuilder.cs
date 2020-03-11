using Quizard.API.Dtos;
using System.Collections.Generic;

namespace Quizard.Tests.Builders
{
    public class CreateQuestionDtoBuilder
    {
        private string _text;
        private List<CreateAnswerDto> _answers = new List<CreateAnswerDto>() { };
        private int[] _categories = new int[] {  };

        public CreateQuestionDto Build()
        {
            return new CreateQuestionDto() { Answers = _answers, Categories = _categories, Text = _text };
        }
        public CreateQuestionDtoBuilder WithAnswers(List<CreateAnswerDto> list)
        {
            _answers = list;
            return this;
        }

        public CreateQuestionDtoBuilder WithCategories(int[] categories)
        {
            _categories = categories;
            return this;
        }

        public CreateQuestionDtoBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

    }
}
