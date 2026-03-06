using Tracked.Domain.Entities;

namespace Tracked.Domain.Interfaces
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}
