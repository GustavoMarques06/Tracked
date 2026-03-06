using Microsoft.EntityFrameworkCore;
using Tracked.Domain.Entities;
using Tracked.Domain.Interfaces;
using Tracked.Infrastructure.Context;

namespace Tracked.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task DeleteAsync(Guid usuarioId, Guid musicaId)
        {
            var review = await GetByIdsAsync(usuarioId, musicaId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Review?> GetByIdsAsync(Guid usuarioId, Guid musicaId)
        {
            return await _context.Reviews
                .FirstOrDefaultAsync(r => r.UsuarioId == usuarioId && r.MusicaId == musicaId);
        }

        public async Task<IEnumerable<Review>> GetByMusicaIdAsync(Guid musicaId)
        {
            return await _context.Reviews
                .Where(r => r.MusicaId == musicaId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }
    }
}
