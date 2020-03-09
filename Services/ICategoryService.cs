using Quizard.API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetCategories(string searchTerm);
        Task<GetCategoryDto> Post(CreateCategoryDto categoryDto);

    }
}
