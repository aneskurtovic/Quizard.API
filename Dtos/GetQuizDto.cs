using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class GetQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionForQuizDto> Questions { get; set; }
    }
}
