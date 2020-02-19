using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class FinishSessionDto
    {
        [Required]
        public Dictionary<int, int[]> QuizResult { get; set; } = new Dictionary<int, int[]>();
    }
}
