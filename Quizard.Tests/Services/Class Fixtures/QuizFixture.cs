using FakeItEasy;
using Quizard.API.Data;

namespace Quizard.Tests.Services.Class_Fixtures
{
    public class QuizFixture
    {
        public IQuizRepository _repo { get; private set; }

        public QuizFixture()
        {
            _repo = A.Fake<IQuizRepository>();
        }
    }
}
