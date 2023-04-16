using Bookstore.Application.Common.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IAuthorService:IBaseService<AuthorDto>
    {
        Task<Response<bool>> SetSoftDeleteAsync(int id);

        Task<Response<IEnumerable<AuthorDto>>> GetSoftDeletedAuthorsAsync();

        Task<Response<IEnumerable<AuthorDto>>> SearchByLastNameAsync(string authorName);
    }
}
