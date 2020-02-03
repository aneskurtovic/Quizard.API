using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Dtos
{

    public class QuizToPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int[] QuestionIds { get; set; }
    }
}
