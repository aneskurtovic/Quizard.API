using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Timer { get; set; }
        public IEnumerable<GetQuestionForQuizDto> Questions { get; set; }
    }
}
