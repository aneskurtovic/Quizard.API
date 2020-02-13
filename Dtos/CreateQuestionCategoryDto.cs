using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateQuestionCategoryDto
    {
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
