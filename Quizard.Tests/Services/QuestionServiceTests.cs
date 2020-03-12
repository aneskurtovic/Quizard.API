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
using System.Linq;
using FakeItEasy;

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
            var question = new Question
            {
                Id = 1,
                Text = "Question",
                CreatedDate = DateTime.Now,
                QuestionsCategories = new List<QuestionCategory> { new QuestionCategory { CategoryID = 1, QuestionID = 1 }, new QuestionCategory { CategoryID = 1, QuestionID = 2 }},
                QuizzesQuestions = new List<QuizQuestion> { new QuizQuestion { QuizId = 1, QuestionId = 1 }, new QuizQuestion { QuizId = 1, QuestionId = 2 }, new QuizQuestion { QuizId = 1, QuestionId = 5 } },
                Answers = new List<Answer> { new Answer { Id = 1, IsCorrect = true, Text = "Answer 1", QuestionId = 1 }, new Answer { Id = 2, IsCorrect = true, Text = "Answer 2", QuestionId = 1 } }
            };

            var questionDto = new CreateQuestionDtoBuilder()
                .WithText(question.Text)
                .WithAnswers(question.Answers.Select(x => new CreateAnswerDto { Text = x.Text, IsCorrect = x.IsCorrect }).ToList())
                .WithCategories(question.QuestionsCategories.Select(x => x.QuestionID).ToArray())
                .Build();

            A.CallTo(() => mockRepository._repo.AddQuestion(A<Question>._)).Returns(Task.FromResult(question));

            var executionRecord = await Record.ExceptionAsync(() => service.AddQuestionAndCategory(questionDto));

            executionRecord.Should().BeNull();

        }
    }
}

