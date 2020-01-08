using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizard.API.Models;

namespace Quizard.API.Dtos
{
    public class QuestionForDetailedDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ICollection<AnswerForDetailedDto> Answers { get; set; }
    }
}
