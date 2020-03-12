using FakeItEasy;
using Quizard.API.Data;

namespace Quizard.Tests.Services.Class_Fixtures
{
    public class SessionFixture
    {
        public ISessionRepository _repo { get; private set; }

        public SessionFixture()
        {
            _repo = A.Fake<ISessionRepository>();
        }
    }
}
