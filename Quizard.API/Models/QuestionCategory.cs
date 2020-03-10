namespace Quizard.API.Models
{
    public class QuestionCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
