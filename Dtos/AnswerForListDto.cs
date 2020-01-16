using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{
    public class AnswerForListDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
