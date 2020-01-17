using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionForListDto
    {
        public string Text { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
