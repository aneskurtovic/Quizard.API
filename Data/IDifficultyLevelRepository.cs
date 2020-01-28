using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IDifficultyLevelRepository
    {
        Task<IEnumerable<DifficultyLevel>> GetDifficultyLevels();
    }
}
