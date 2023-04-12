using Bookstore.Application.Common.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<BaseResponse<AuthorDto>> CreateAsync(T model);
        Task<BaseResponse<AuthorDto>> UpdateAsync(T model);
        Task<BaseResponse<bool>> DeleteAsync(int id);
        Task<BaseResponse<T>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<T>>> GetAllAsync();
    }
}
