using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface ICartDetailRepository
    {
        Task CreateAsync(CartDetailDto cartDetailDto);

        Task DeleteCartDetailAsync(int cartId, int bookId, int quantity);

        Task AddCartDetailAsync(int cartId, int bookId, int quantity);

        Task<IEnumerable<CartDetailsPreview>> GetCartDetailsByUserIdAsync(string userId);

        Task<bool> IsExistCartDetailAsync(int cartId, int bookId);
    }
}
