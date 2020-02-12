using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{
    public class SessionResultDto
    {
        public double Result { get; set; }
        public Dictionary<int, bool> CorrectQuestions { get; set; }

        public SessionResultDto()
        {
            CorrectQuestions = new Dictionary<int, bool>();
        }
    }
}
