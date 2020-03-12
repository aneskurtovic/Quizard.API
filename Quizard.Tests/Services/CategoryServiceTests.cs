using System;
using System.Threading.Tasks;
using Quizard.API.Dtos;
using Quizard.API.Services;
using Quizard.Tests.Services.Class_Fixtures;
using Quizard.Tests.Services.Collection_Fixtures;
using Xunit;

namespace Quizard.Tests.Services
{
    [Collection("Mapper collection")]
    public class CategoryServiceTests : IClassFixture<CategoryFixture>
    {
        CategoryFixture mockRepository;
        MapperFixture mapperFixture;

        public CategoryServiceTests(CategoryFixture _mockRepository, MapperFixture mapper)
        {
            mockRepository = _mockRepository;
            mapperFixture = mapper;
        }

        [Fact]
        public async Task GivenWhiteSpaceToSearchTerm_WhenGetCategoryInvoked_ShouldThrowException()
        {
            var service = new CategoryService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.GetCategories("   ");

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenEmtpyToSearchTerm_WhenGetCategoryInvoked_ShouldThrowException()
        {
            var service = new CategoryService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.GetCategories(string.Empty);

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenWhiteSpaceToCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            var service = new CategoryService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = "   "
                }
            );

            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenEmptyCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            var service = new CategoryService(mockRepository._repo, mapperFixture._mapper);

            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = string.Empty
                }
            );

            await Assert.ThrowsAsync<Exception>(action);
        }

    }
}
