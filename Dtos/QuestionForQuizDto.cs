using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionForQuizDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<AnswerForQuizDto> Answers { get; set; }
    }
}
