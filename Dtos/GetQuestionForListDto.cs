using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class GetQuestionForListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public IEnumerable<string> Categories { get; set; }
    }
}
