using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ICategoryRepository
    {
        Task Add<T>(T entity) where T : class;
        Task<List<Category>> GetCategories();
        Task<bool> SaveAll();
    }
}
