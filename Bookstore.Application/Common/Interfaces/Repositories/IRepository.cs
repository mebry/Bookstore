namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T?>> GetAllAsync();

        Task SaveChangesAsync();
    }
}
