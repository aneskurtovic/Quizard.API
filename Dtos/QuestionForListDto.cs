using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizard.API.Models;

namespace Quizard.API.Dtos
{
    public class QuestionForListDto
    {
        public string Text { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
