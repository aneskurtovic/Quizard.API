using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateAnswerDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
    }
}
