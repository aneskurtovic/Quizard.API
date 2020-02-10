using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class SessionToPostDto
    {
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string QuizTakerName { get; set; }
    }
}
