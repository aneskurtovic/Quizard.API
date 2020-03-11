using FakeItEasy;
using Quizard.API.Data;
using Quizard.API.Services;
using Xunit;

using Quizard.Tests.Builders;
using Quizard.API.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.Tests.Services
{
    public class QuestionServiceTests : BaseServiceTest
    {
        public QuestionServiceTests() : base()
        {

        }

        [Fact]
        public async Task GivenNoAnswersInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<IQuestionRepository>();
            var service = new QuestionService(mockRepository, _mapper);

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
            var mockRepository = A.Fake<IQuestionRepository>();
            var service = new QuestionService(mockRepository, _mapper);

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
            var mockRepository = A.Fake<IQuestionRepository>();
            var service = new QuestionService(mockRepository, _mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(new CreateQuestionDtoBuilder().BuildWithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Nesto", IsCorrect = true } }).BuildWithCategories(new int[] { 1 }).Build());

            await Assert.ThrowsAsync<Exception>(action);

            //result.Should().BeEquivalentTo(new CreateQuestionCategoryDto { })
        }
    }
}

