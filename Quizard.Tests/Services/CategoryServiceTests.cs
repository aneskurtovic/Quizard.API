using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FakeItEasy;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Services;
using Xunit;

namespace Quizard.Tests.Services
{
    public class CategoryServiceTests: BaseServiceTest
    {
        public CategoryServiceTests() : base()
        {

        }

        [Fact]
        public async Task GivenWhiteSpaceToSearchTerm_WhenGetCategoryInvoked_ShouldThrowException()
        {
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            Func<Task> action = async () => await service.GetCategories("   ");

            await Assert.ThrowsAsync<ValidationException>(action);
        }

        [Fact]
        public async Task GivenEmtpyToSearchTerm_WhenGetCategoryInvoked_ShouldThrowException()
        {
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            Func<Task> action = async () => await service.GetCategories(string.Empty);

            await Assert.ThrowsAsync<ValidationException>(action);
        }

        [Fact]
        public async Task GivenWhiteSpaceToCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = "   "
                }
            );

            await Assert.ThrowsAsync<ValidationException>(action);
        }

        [Fact]
        public async Task GivenEmptyCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = string.Empty
                }
            );

            await Assert.ThrowsAsync<ValidationException>(action);
        }

    }
}
