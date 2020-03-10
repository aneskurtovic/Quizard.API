using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class ResponseQuizDto
    {
        [Required]
        public int Id { get; set; }
    }
}
