﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuizQuestion> QuizzesQuestions { get; set; }
    }
}
