using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class FinishSessionDto
    {
        public Dictionary<int, int[]> QuizResult { get; set; } = new Dictionary<int,int []>();
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string SessionId { get; set; }
    }
}
