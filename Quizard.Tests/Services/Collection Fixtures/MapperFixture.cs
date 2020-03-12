using AutoMapper;
using Quizard.API.Helpers;

namespace Quizard.Tests.Services.Collection_Fixtures
{
    public class MapperFixture
    {
        public IMapper _mapper { get; private set; }
       
        public MapperFixture()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            _mapper = mockMapper.CreateMapper();
        }
    }
}
