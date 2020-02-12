using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionForDetailedListDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<AnswerForDetailedListDto> Answers { get; set; }
        public int DifficultyLevelId { get; set; }
    }
}
