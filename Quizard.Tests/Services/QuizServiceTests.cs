using FakeItEasy;
using FluentAssertions;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using Quizard.API.Services;
using Quizard.Tests.Builders;
using Quizard.Tests.Services.Class_Fixtures;
using Quizard.Tests.Services.Collection_Fixtures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Quizard.Tests.Services
{
    [Collection("Mapper collection")]
    public class QuizServiceTests : IClassFixture<QuizFixture>
    {
        QuizFixture mockRepository;
        MapperFixture mapperFixture;

        public QuizServiceTests(QuizFixture _mockRepository, MapperFixture mapper) : base() {
            mockRepository = _mockRepository;
            mapperFixture = mapper;
        }

        [Fact]
        public async Task GivenNoQuizNameInDto_WhenAddQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName(null)
                .WithTimer(1)
                .WithQuestionIds(new int[] { 1 })
                .Build()                
                );

            var exception = await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenEmptyQuizNameInDto_WhenAddQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName("")
                .WithTimer(1)
                .WithQuestionIds(new int[] { 1 })
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenZeroMinutesTimerInDto_WhenAddQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName("Test Quiz")
                .WithTimer(0)
                .WithQuestionIds(new int[] { 1 })
                .Build() 
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNegativeMinutesTimerInDto_WhenAddQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName("Test Quiz")
                .WithTimer(-5)
                .WithQuestionIds(new int[] { 1 })
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoQuestionsInDto_WhenAddQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName("Test Quiz")
                .WithTimer(1)
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNameQuestionsAndTimer_WhenAddQuizInvoked_ShouldReturnQuiz()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.AddQuiz(
                new CreateQuizDtoBuilder()
                .WithName("Quizard")
                .WithTimer(1)
                .WithQuestionIds(new int[] { 1,2,5 })
                .Build()
                );

            //Assert.IsType<Quiz>(result);
            //Assert.Equal(result, new Quiz() { Name = "Quizard", Timer = 1 });

            //result.Should().BeOfType<Quiz>();
            //result.Should().BeEquivalentTo(new Quiz() { Name = "Quizard", Timer = 1 });
        }

        [Fact]
        public async Task WhenGetLeaderboardInvoked_ShouldReturnListOfGetQuizForLeaderboardDtos()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.GetLeaderboard();

            result.Should().BeOfType<List<GetQuizForLeaderboardDto>>();
        }

        [Fact]
        public async Task GivenNegativeOrZeroQuizId_WhenGetQuizInvoked_ShouldThrowException()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.GetQuiz(-5);

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenValidQuizId_WhenGetQuizInvoked_ShouldReturnQuiz()
        {
            var service = new QuizService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.GetQuiz(5);

            result.Should().BeOfType<GetQuizDto>();
        }
    }
}
