using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionForPostDto
    {
        public string Text { get; set; }
        public ICollection<AnswerForPostDto> Answers { get; set; }
    }
}
