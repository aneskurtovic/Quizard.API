using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizard.API.Models;

namespace Quizard.API.Dtos
{
    public class QuestionForPostDto
    {
        public string QuestionText { get; set; }
        public ICollection<AnswerForPostDto> Answers { get; set; }
    }
}
