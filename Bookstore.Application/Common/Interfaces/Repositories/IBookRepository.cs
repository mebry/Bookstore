using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IBookRepository:IRepository<BookDto>
    {
        Task<IEnumerable<BookPreview>> SearchByNameAsync(string name);

        Task<bool> SetSoftDeleteAsync(int id);

        Task<IEnumerable<BookDto>> GetSoftDeletedBooksAsync();

        Task<IEnumerable<BookDto>> GetBooksByGenreAsync(List<int> genresId);

        Task<IEnumerable<BookPreview>> GetBookPreviewsAsync();

        Task<BookDetails> GetBookDetailsAsync(int id);
    }
}
