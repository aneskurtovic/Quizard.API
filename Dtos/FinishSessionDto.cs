using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{
    public class FinishSessionDto
    {
        public Dictionary<int, int> QuizResult { get; set; } = new Dictionary<int, int>();
    }
}
