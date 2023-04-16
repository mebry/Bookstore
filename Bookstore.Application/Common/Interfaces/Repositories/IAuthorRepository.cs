using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<AuthorDto>
    {
        Task<bool> SetSoftDeleteAsync(int id);

        Task<IEnumerable<AuthorDto>> GetSoftDeletedAuthorsAsync();

        Task<IEnumerable<AuthorDto>> SearchByLastNameAsync(string authorName);
    }
}
