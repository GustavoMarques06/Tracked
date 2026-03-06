using Tracked.Domain.Entities;

namespace Tracked.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review?> GetByIdsAsync(Guid usuarioId, Guid musicaId);
        Task<IEnumerable<Review>> GetByMusicaIdAsync(Guid musicaId);
        Task<Review> CreateAsync(Review review);
        Task DeleteAsync(Guid usuarioId, Guid musicaId);
        Task UpdateAsync(Review review);
    }
}
