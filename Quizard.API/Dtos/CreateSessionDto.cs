using System;
using System.ComponentModel.DataAnnotations;

namespace Quizard.API.Dtos
{
    public class CreateSessionDto
    {
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string ContestantName { get; set; }
    }
}
