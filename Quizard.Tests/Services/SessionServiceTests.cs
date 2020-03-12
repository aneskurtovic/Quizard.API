using FakeItEasy;
using FluentAssertions;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using Quizard.API.Services;
using Quizard.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Quizard.Tests.Services
{
    public class SessionServiceTests : BaseServiceTest
    {
        public SessionServiceTests() : base()
        {

        }

        [Fact]
        public async Task GivenNoContestantNameInDto_WhenAddSessionInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildQuizId(1).Build());


            //Then 
            await action.Should().ThrowAsync<Exception>().WithMessage("Contestant name cannot be empty.");
        }

        [Fact]
        public async Task GivenNoQuizId_WhenAddSessionInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").Build());

            //Then 
            await action.Should().ThrowAsync<Exception>().WithMessage("Quiz Id cannot be lesser than 1.");
        }

        [Fact]
        public async Task GivenQuizIdZero_WhenAddSessionInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").BuildQuizId(0).Build());

            //Then
            await action.Should().ThrowAsync<Exception>().WithMessage("Quiz Id cannot be lesser than 1.");


        }
        [Fact]
        public async Task GivenQuizIdAndContestantName_WhenAddSessionInvoked_ShouldNotBeNull()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            var result = await service.AddSession(new CreateSessionDtoBuilder().BuildContestantName("Contestant").BuildQuizId(2).Build());

            //Then 
            result.Should().BeEquivalentTo(new ResponseSessionDto
            {
                QuizId = result.QuizId
            });
        }

        [Fact]
        public async Task GivenNoSessionId_WhenGetSession_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            var guid = "";
            Func<Task> action = async () => await service.GetSession(guid);

            //Then 
            await action.Should().ThrowAsync<Exception>().WithMessage("Session Id cannot be empty.");
        }

        [Fact]
        public async Task GivenNoAnswersInDictionary_WhenGetResults_ShouldReturnResultZero()
        {
            //Given
            var mockRepository = A.Fake<ISessionRepository>();
            var service = new SessionService(mockRepository, _mapper);

            //When
            var result = await service.GetResult(new CreateFinishSessionDtoBuilder().BuildQuizId(1).BuildSessionId("123123").Build());

            //Then 
            Assert.Equal(0, result.Result);
        }


    }
}
