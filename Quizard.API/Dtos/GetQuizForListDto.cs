namespace Quizard.API.Dtos
{
    public class GetQuizForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Timer { get; set; }

    }
}
