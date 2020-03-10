using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetCategoryDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
