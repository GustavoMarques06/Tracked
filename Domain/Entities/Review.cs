namespace Tracked.Domain.Entities
{
    public class Review
    {
        // Chaves estrangeiras
        public Guid UsuarioId { get; set; }
        public Guid MusicaId { get; set; }

        // Propriedades de Navegação (Maiúsculas para o EF)
        public virtual Usuario Usuario { get; set; }
        public virtual Musica Musica { get; set; }

        // Dados da Review
        public int Nota { get; set; }
        public string TextoReview { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
