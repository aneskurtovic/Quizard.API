using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Services;
using Quizard.Tests.Builders;
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
            //Given
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.GetCategories("   ");

            //Then 
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenEmtpyToSearchTerm_WhenGetCategoryInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.GetCategories(string.Empty);

            //Then 
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenWhiteSpaceToCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = "   "
                }
            );

            //Then 
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GivenEmptyCategoryName_WhenAddCategoryInvoked_ShouldThrowException()
        {
            //Given
            var mockRepository = A.Fake<ICategoryRepository>();
            var service = new CategoryService(mockRepository, _mapper);

            //When
            Func<Task> action = async () => await service.Post(
                new CreateCategoryDto()
                {
                    Name = string.Empty
                }
            );

            //Then 
            await Assert.ThrowsAsync<Exception>(action);
        }

    }
}
