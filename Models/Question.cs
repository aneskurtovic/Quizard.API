using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
