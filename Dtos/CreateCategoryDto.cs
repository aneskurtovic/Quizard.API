using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
