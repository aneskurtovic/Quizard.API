using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface IDifficultyLevelRepository
    {
        Task<IEnumerable<DifficultyLevel>> GetDifficultyLevels();
    }
}
