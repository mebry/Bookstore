using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IBookService : IBaseService<BookDto>
    {
        Task<Response<bool>> SetSoftDeleteAsync(int id);

        Task<Response<IEnumerable<BookDto>>> GetSoftDeletedBooksAsync();

        Task<Response<IEnumerable<BookDto>>> SearchByNameAsync(string name);

        Task<Response<IEnumerable<BookPreview>>> GetBookPreviewsAsync();
    }
}
