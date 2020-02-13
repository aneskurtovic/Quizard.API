using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateQuizDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int[] QuestionIds { get; set; }
    }
}
