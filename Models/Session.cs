using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Session()
        {
            StartedAt = DateTime.Now;
        }
    }
}
