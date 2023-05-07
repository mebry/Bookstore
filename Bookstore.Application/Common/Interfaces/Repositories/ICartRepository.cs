using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<CartDto> CreateAsync(CartDto entity);

        Task<bool> IsExistUserCartAsync(string userId);

        Task<CartDto> GetByUserIdAsync(string userId);

        Task ResetCartAsync(int cartId);
    }
}
