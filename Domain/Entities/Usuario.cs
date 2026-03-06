using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Tracked.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
