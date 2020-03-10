using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetSessionDto
    {
        [Required]
        public string Name { get; set; }
        public int TimeLeft { get; set; }
        public IEnumerable<GetQuestionForQuizDto> Questions { get; set; }
    }
}
