namespace Tracked.Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public string Descricao { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
