using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddCategory<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<Category>> GetCategories(string searchTerm)
        {
            return await _context.Categories.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                      .Take(10)
                                      .ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
