using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddCategory<T>(T entity) where T : class
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task<List<Category>> GetCategories(string searchTerm)
        {
            return await db.Categories.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                      .Take(10)
                                      .ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}
