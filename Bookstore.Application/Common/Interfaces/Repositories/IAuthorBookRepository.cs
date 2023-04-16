using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IAuthorBookRepository
    {
        Task CreateAsync(AuthorBookDto entity);

        Task UpdateAsync(AuthorBookDto entity);

        Task DeleteAsync(AuthorBookDto entity);

        Task<IEnumerable<AuthorBookDto>> GetAllAsync();
    }
}
