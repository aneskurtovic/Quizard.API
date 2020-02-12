using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{

    public class QuizToPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int[] QuestionIds { get; set; }
    }
}
