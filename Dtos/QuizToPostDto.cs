using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{
    public class QuizToPostDto
    {
        public string Name { get; set; }
        public int[] Questions { get; set; }
    }
}
