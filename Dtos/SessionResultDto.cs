using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class SessionResultDto
    {
        public double Result { get; set; }
        public Dictionary<int, int> CorrectQuestions { get; set; }

        public SessionResultDto()
        {
            CorrectQuestions = new Dictionary<int, int>();
        }
    }
}
