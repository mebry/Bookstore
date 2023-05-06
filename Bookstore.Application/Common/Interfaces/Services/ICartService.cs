using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface ICartService
    {
        Task<Response<bool>> AddCartDetailAsync(string userId, int bookId, int quantity);

        Task<Response<IEnumerable<CartDetailsPreview>>> GetCartDetailsByUserIdAsync(string userId);

        Task<Response<bool>> DeleteCartDetailAsync(string userId, int bookId, int quantity);
    }
}
