using System;

namespace Quizard.API.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string QuizTakerName { get; set; }
        public Session()
        {
            StartDate = DateTime.Now;
        }
    }
}
