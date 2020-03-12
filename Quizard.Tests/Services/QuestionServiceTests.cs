using FakeItEasy;
using Quizard.API.Data;
using Quizard.API.Services;
using Xunit;
using Quizard.Tests.Builders;
using Quizard.API.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Quizard.API.Models;
using Quizard.Tests.Services.Class_Fixtures;
using Quizard.Tests.Services.Collection_Fixtures;

namespace Quizard.Tests.Services
{
    [Collection("Mapper collection")]
    public class QuestionServiceTests : IClassFixture<QuestionFixture>
    {
        QuestionFixture mockRepository;
        MapperFixture mapperFixture;

        public QuestionServiceTests(QuestionFixture _mockRepository, MapperFixture mapper)
        {
            mockRepository = _mockRepository;
            mapperFixture = mapper;
        }

        [Fact]
        public async Task GivenNoAnswersInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .WithText("Questionss")
                .WithCategories(new int[] { 1 })
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoCategoriesInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .WithText("Questions")
                .WithAnswers(new List<CreateAnswerDto> 
                { 
                    new CreateAnswerDto 
                    {
                        Text = "Answer 1",
                        IsCorrect = true 
                    },
                    new CreateAnswerDto 
                    {
                        Text = "Answer 2", 
                        IsCorrect = false 
                    } 
                })
                .Build()
                );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoTextInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
               .WithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Answer", IsCorrect = true } })
               .WithCategories(new int[] { 1 })
               .Build()
               );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenNoCorrectAnswerInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .WithText("Questionss")
                .WithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Nesto", IsCorrect = false } })
                .WithCategories(new int[] { 1 })
                .Build()
                );
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenOnlyOneAnswerInDto_WhenAddQuestionAndCategoryInvoked_ShouldThrowException()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.AddQuestionAndCategory(
                new CreateQuestionDtoBuilder()
                .WithText("Questionss")
                .WithAnswers(new List<CreateAnswerDto> { new CreateAnswerDto { Text = "Nesto", IsCorrect = true } })
                .WithCategories(new int[] { 1 })
                .Build()
                );
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenQuestionCategoriesAndAnswers_WhenAddQuestionInvoked_ShouldReturnQuestion()
        {
            var service = new QuestionService(mockRepository._repo, mapperFixture._mapper);

            var result = await service.AddQuestionAndCategory(
                 new CreateQuestionDtoBuilder()
                 .WithText("Question")
                 .WithAnswers(new List<CreateAnswerDto> { 
                     new CreateAnswerDto { 
                         Text = "Answer 1", IsCorrect = true 
                     },
                     new CreateAnswerDto {
                         Text = "Answer 2", IsCorrect = false 
                     } 
                 })
                 .WithCategories(new int[] { 1 })
                 .Build()
                 );
            result.Should().BeEquivalentTo(new Question() 
            {
                CreatedDate = result.CreatedDate,
                Text = "Question",
                Answers = new List<Answer>() 
                { 
                new Answer 
                    {
                        IsCorrect = true,
                        Text = "Answer 1"
                    },
                new Answer 
                    {
                        IsCorrect = false,
                        Text = "Answer 2"
                    }
                }
            });
        }
    }
}

