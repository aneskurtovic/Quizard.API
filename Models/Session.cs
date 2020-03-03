using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Models
{
    public class Session
    {
        [Key]
        public Guid Id { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string ContestantName { get; set; }
        public int Result { get; set; }


        public Session()
        {
            StartedAt = DateTime.Now;
        }
    }
}
