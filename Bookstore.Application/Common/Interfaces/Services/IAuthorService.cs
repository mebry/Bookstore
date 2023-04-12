using Bookstore.Application.Common.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IAuthorService:IBaseService<AuthorDto>
    {
        Task<BaseResponse<bool>> SetSoftDeleteAsync(int id);

        Task<BaseResponse<IEnumerable<AuthorDto>>> GetSoftDeletedAuthorsAsync();

        Task<BaseResponse<IEnumerable<AuthorDto>>> SearchByLastNameAsync(string authorName);
    }
}
