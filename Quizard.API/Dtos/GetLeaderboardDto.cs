using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class GetLeaderboardDto
    {
        public List<GetSessionForLeaderboardDto> Top10 { get; set; }
    }
}
