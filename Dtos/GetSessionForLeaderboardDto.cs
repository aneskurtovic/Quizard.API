using System;

namespace Quizard.API.Dtos
{
    public class GetSessionForLeaderboardDto
    {
        public int Result { get; set; }
        public string ContestantName { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
