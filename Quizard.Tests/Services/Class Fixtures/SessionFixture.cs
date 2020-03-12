using FakeItEasy;
using Quizard.API.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
