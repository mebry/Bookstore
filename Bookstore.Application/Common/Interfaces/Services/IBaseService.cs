using Bookstore.Application.Common.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<Response<T>> CreateAsync(T model);
        Task<Response<T>> UpdateAsync(T model);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<T>> GetByIdAsync(int id);
        Task<Response<IEnumerable<T>>> GetAllAsync();
    }
}
