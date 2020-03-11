using System.Collections.Generic;

namespace Quizard.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuestionCategory> QuestionsCategories { get; set; }
    }
}
