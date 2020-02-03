using System.Collections.Generic;

namespace Quizard.API.Models
{
    public class Quiz
    {
        public Quiz()
        {
            QuizzesQuestions = new List<QuizQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuizQuestion> QuizzesQuestions { get; set; }
    }
}
