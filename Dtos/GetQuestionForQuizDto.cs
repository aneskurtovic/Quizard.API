using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetQuestionForQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public IEnumerable<GetAnswerDto> Answers { get; set; }
    }
}
