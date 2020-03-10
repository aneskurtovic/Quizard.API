namespace Quizard.API.Models
{
    public class QuizQuestion
    {
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
