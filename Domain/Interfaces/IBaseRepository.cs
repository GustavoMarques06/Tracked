namespace Tracked.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> Create(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> Update(T entity);
        public Task Delete(Guid id);

    }
}
