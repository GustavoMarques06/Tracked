namespace Tracked.Domain.Entities
{
    public abstract class PerfilMusica : BaseEntity
    {
        public string Biografia { get; set; }
        public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
