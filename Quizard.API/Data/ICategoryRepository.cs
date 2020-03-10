using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetCategories(string searchTerm);
        Task<Category> CategoryExists(string name);
    }
}