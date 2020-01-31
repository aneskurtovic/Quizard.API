using System;
using System.Collections.Generic;

namespace Quizard.API.Dtos
{
    public class QuestionForListDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
