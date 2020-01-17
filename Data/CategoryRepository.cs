using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System.Collections.Generic;
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
        public async Task Add<T>(T entity) where T : class
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await db.Categories.Include(a => a.QuestionsCategories).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}
