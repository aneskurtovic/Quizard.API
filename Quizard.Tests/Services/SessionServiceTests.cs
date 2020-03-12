using FluentAssertions;
using Quizard.API.Dtos;
using Quizard.API.Services;
using Quizard.Tests.Builders;
using Quizard.Tests.Services.Class_Fixtures;
using Quizard.Tests.Services.Collection_Fixtures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Quizard.Tests.Services
{
    [Collection("Mapper collection")]
    public class SessionServiceTests : IClassFixture<SessionFixture>
    {
        SessionFixture mockRepository;
        MapperFixture mapperFixture;

        public SessionServiceTests(SessionFixture _mockRepository, MapperFixture mapper)
        {
            mockRepository = _mockRepository;
            mapperFixture = mapper;
        }

        [Fact]
        public async Task GivenNoContestantNameInDto_WhenAddSessionInvoked_ShouldThrowException()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildQuizId(1).Build());


            //Then 
            await action.Should().ThrowAsync<ValidationException>().WithMessage("Contestant name cannot be empty.");
        }

        [Fact]
        public async Task GivenNoQuizId_WhenAddSessionInvoked_ShouldThrowException()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").Build());

            //Then 
            await action.Should().ThrowAsync<ValidationException>().WithMessage("Quiz Id cannot be lesser than 1.");
        }

        [Fact]
        public async Task GivenQuizIdZero_WhenAddSessionInvoked_ShouldThrowException()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").BuildQuizId(0).Build());

            //Then
            await action.Should().ThrowAsync<ValidationException>().WithMessage("Quiz Id cannot be lesser than 1.");
        }

        [Fact]
        public async Task GivenQuizIdAndContestantName_WhenAddSessionInvoked_ShouldNotBeNull()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").BuildQuizId(2).Build());

            result.Should().BeEquivalentTo(new ResponseSessionDto
            {
                QuizId = result.QuizId
            });
        }

        [Fact]
        public async Task GivenNoSessionId_WhenGetSession_ShouldThrowException()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            var guid = "";
            Func<Task> action = async () => await service.GetSession(guid);

            //Then 
            await action.Should().ThrowAsync<ValidationException>().WithMessage("Session Id cannot be empty.");
        }

        [Fact]
        public async Task GivenNoAnswersInDictionary_WhenGetResults_ShouldReturnResultZero()
        {
            var service = new SessionService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.GetResult(new CreateFinishSessionDtoBuilder().BuildQuizId(1).BuildSessionId("123123").Build());

            Assert.Equal(0, result.Result);
        }
    }
}
