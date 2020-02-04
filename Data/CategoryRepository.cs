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
        public async Task AddCategory(Category category) 
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories(string searchTerm)
        {
            return await _context.Categories.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public async Task<Category> CategoryExists(string name)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Name.Trim() == name.Trim());
            return exist;
        }
    }
}
