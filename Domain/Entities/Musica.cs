using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Tracked.Domain.Entities
{
    public class Musica : BaseEntity
    {
        public int Duracao { get; set; }
        public virtual ICollection<PerfilMusica> Artistas { get; set; } = new List<PerfilMusica>();
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
