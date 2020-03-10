using AutoMapper;
using Quizard.API.Helpers;

namespace Quizard.Tests.Services
{
    public class BaseServiceTest
    {
        protected readonly IMapper _mapper;

        public BaseServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            _mapper = mockMapper.CreateMapper();
        }
    }
}