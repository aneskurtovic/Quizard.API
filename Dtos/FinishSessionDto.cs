using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class FinishSessionDto
    {
        public Dictionary<int, int> QuizResult { get; set; } = new Dictionary<int, int>();
    }
}
