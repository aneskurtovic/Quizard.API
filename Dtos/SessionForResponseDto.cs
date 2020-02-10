using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class SessionForResponseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int QuizId { get; set; }
    }
}
