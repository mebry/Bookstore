using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IBookService : IBaseService<BookDto>
    {
        Task<Response<bool>> SetSoftDeleteAsync(int id);

        Task<Response<IEnumerable<BookDto>>> GetSoftDeletedBooksAsync();

        Task<Response<IEnumerable<BookPreview>>> SearchByNameAsync(string name);

        Task<Response<IEnumerable<BookPreview>>> GetBookPreviewsAsync();

        Task<Response<BookDetails>> GetBookDetailsAsync(int id);

        Task<Response<BookWithAuthors>> UpdateBookDetailsAsync(BookWithAuthors bookWithAuthors);

        Task<Response<BookWithAuthors>> CreatBookWithAuthorsAsync(BookWithAuthors bookWithAuthors);

        Task<Response<BookWithAuthors>> GetBookWithAuthors(int id);

    }
}
