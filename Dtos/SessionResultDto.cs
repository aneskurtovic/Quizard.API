using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class SessionResultDto
    {
        [Required]
        public double Result { get; set; }
        [Required]
        public Dictionary<int, int> CorrectQuestions { get; set; }

        public SessionResultDto()
        {
            CorrectQuestions = new Dictionary<int, int>();
        }
    }
}
