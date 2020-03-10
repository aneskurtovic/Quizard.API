using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetDifficultyLevelDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Level { get; set; }
    }
}
