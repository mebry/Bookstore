using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IAuthorBookRepository
    {
        Task CreateAsync(AuthorBookDto entity);

        Task DeleteAsync(AuthorBookDto entity);

        Task<IEnumerable<AuthorBookDto>> GetAllAsync();

        Task<IEnumerable<AuthorBookDto>> GetByBookIdAsync(int bookId);

        Task DeleteRangeAsync(IEnumerable<AuthorBookDto> authorBooks);

        Task CreateRangeAsync(IEnumerable<AuthorBookDto> authorBooks);
    }
}
