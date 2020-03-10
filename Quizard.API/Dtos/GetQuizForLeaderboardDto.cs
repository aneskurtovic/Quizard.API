using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetQuizForLeaderboardDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
