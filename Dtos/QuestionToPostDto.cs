using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionToPostDto
    {
        public string Text { get; set; }
        public ICollection<AnswerToPostDto> Answers { get; set; }
        public int[] Categories { get; set; }
        public int DifficultyLevelId { get; set; }

    }
}
