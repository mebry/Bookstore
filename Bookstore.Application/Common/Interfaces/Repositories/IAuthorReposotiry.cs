using Bookstore.Domain.Entities;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IAuthorReposotiry : IRepository<AuthorDto>
    {
        Task<bool> SetSoftDeleteAsync(int id);

        Task<IEnumerable<AuthorDto>> GetSoftDeletedAuthorsAsync();

        Task<IEnumerable<AuthorDto>> SearchByLastNameAsync(string authorName);
    }
}
