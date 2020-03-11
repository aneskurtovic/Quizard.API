using FakeItEasy;
using Quizard.API.Data;
using Quizard.API.Services;
using Xunit;
using Quizard.Tests.Builders;
using Quizard.API.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quizard.Tests.Services.Class_Fixtures;
using Quizard.Tests.Services.Collection_Fixtures;

namespace Quizard.Tests.Services
{
    [Collection("Mapper collection")]
    public class QuestionServiceTests : IClassFixture<QuestionFixture>
    {
        QuestionFixture questionFixture;
        MapperFixture mapperFixture;

        public QuestionServiceTests(QuestionFixture questionFixture, MapperFixture mapperFixture) : base()
        {
            this.questionFixture = questionFixture;
            this.mapperFixture = mapperFixture;
        }

        [Fact]
        public async Task GivenNoAnswersInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            
            var service = new QuestionService(questionFixture._repo, mapperFixture._mapper);

            //When
            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .BuildWithText("Questionss")
                .BuildWithCategories(new int[] { 1 })
                .Build()
                );

            //Then 
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoCategoriesInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(questionFixture._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .BuildWithText("Questionss")
                .BuildWithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Nesto", IsCorrect = true } })
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoTextInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(questionFixture._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(new CreateQuestionDtoBuilder().BuildWithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Nesto", IsCorrect = true } }).BuildWithCategories(new int[] { 1 }).Build());

            await Assert.ThrowsAsync<Exception>(action);

            //result.Should().BeEquivalentTo(new CreateQuestionCategoryDto { })
        }
    }
}

