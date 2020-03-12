using FakeItEasy;
using Quizard.API.Data;

namespace Quizard.Tests.Services.Class_Fixtures
{
    public class CategoryFixture
    {
        public ICategoryRepository _repo { get; private set; }

        public CategoryFixture()
        {
            _repo = A.Fake<ICategoryRepository>();
        }
    }
}
