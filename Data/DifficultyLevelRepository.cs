using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class DifficultyLevelRepository : IDifficultyLevelRepository
    {
        private readonly ApplicationDbContext _context;

        public DifficultyLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DifficultyLevel>> GetDifficultyLevels()
        {
            return await _context.DifficultyLevels.ToListAsync();
        }
    }
}
