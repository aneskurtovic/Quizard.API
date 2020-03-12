using FakeItEasy;
using Quizard.API.Data;

namespace Quizard.Tests.Services.Class_Fixtures
{
    public class QuestionFixture
    {
        public IQuestionRepository _repo { get; private set; }

        public QuestionFixture()
        {
            _repo = A.Fake<IQuestionRepository>();
        }
    }
}
