﻿using System;
using System.Collections.Generic;

namespace Quizard.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionCategory> QuestionsCategories { get; set; }
        public int DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

    }
}
