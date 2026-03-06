using Tracked.Domain.Entities;

namespace Tracked.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public Task<Usuario> GetByEmailAsync(string email);
    }
}
