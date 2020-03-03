using System;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetSessionForLeaderboardDto
    {
        [Required]
        public int Result { get; set; }
        [Required]
        public string ContestantName { get; set; }
        [Required]
        public DateTime StartedAt { get; set; }
    }
}
