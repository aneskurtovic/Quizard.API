using Quizard.API.Models;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSession(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();   
        }
    }
}
