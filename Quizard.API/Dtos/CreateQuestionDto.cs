using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateQuestionDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public ICollection<CreateAnswerDto> Answers { get; set; }
        [Required]
        public int[] Categories { get; set; }
    }
}
