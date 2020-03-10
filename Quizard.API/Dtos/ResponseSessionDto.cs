using System;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class ResponseSessionDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int QuizId { get; set; }
    }
}
