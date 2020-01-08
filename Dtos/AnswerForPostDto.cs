using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{
    public class AnswerForPostDto
    {
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
    }
}
