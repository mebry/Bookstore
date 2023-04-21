using Bookstore.Application.Common.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IAuthorBookService
    {
        Task<Response<bool>> CreateAsync(AuthorBookDto entity);

        Task<Response<bool>> DeleteAsync(AuthorBookDto entity);

        Task<Response<IEnumerable<AuthorBookDto>>> GetAllAsync();

        Task<Response<IEnumerable<AuthorBookDto>>> GetByBookIdAsync(int bookId);

        Task<Response<bool>> DeleteRangeAsync(IEnumerable<AuthorBookDto> authorBooks);

        Task<Response<bool>> CreateRangeAsync(IEnumerable<AuthorBookDto> authorBooks);
    }
}
