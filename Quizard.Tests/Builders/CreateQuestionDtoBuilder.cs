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
        public CreateQuestionDtoBuilder BuildWithAnswers(List<CreateAnswerDto> list)
        {
            _answers = list;
            return this;
        }

        public CreateQuestionDtoBuilder BuildWithCategories(int[] categories)
        {
            _categories = categories;
            return this;
        }

        public CreateQuestionDtoBuilder BuildWithText(string text)
        {
            _text = text;
            return this;
        }

    }
}
