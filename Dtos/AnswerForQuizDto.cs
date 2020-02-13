using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class AnswerForQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
