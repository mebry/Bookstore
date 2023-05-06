using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<CartDto> CreateAsync(CartDto entity);

        Task<bool> IsExistUserCart(string userId);

        Task<CartDto> GetByUserId(string userId);
    }
}
