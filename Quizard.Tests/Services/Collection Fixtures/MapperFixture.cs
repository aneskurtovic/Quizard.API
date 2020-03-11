using AutoMapper;
using Quizard.API.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

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
