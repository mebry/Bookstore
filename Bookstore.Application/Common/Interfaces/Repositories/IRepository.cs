namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T?>> GetAllAsync();
    }
}
