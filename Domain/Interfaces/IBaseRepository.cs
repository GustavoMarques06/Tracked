namespace Tracked.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> CreateAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);

    }
}
