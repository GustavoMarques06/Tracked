using Microsoft.EntityFrameworkCore;
using Tracked.Domain.Entities;
using Tracked.Domain.Interfaces;
using Tracked.Infrastructure.Context;

namespace Tracked.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Set<Usuario>()
            .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
