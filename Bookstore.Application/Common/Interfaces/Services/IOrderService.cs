using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Response<bool>> CreateOrderAsync(string userId);

        Task<Response<IEnumerable<OrderInformation>>> GetOrdersByUserAsync(string userId);
    }
}
