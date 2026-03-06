using Microsoft.EntityFrameworkCore;
using Tracked.Domain.Entities;

namespace Tracked.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Definição das Tabelas
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<PerfilMusica> PerfisMusicais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(r => new { r.UsuarioId, r.MusicaId });

            entity.HasOne(r => r.Usuario)
                  .WithMany(u => u.Reviews)
                  .HasForeignKey(r => r.UsuarioId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Musica)
                  .WithMany(m => m.Reviews)
                  .HasForeignKey(r => r.MusicaId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PerfilMusica>()
            .HasDiscriminator<string>("TipoPerfil")
            .HasValue<ArtistaSolo>("ArtistaSolo")
            .HasValue<Banda>("Banda");

        modelBuilder.Entity<Playlist>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Playlists)
            .HasForeignKey(p => p.UsuarioId);
    }
}