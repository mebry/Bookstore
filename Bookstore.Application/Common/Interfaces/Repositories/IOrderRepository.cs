using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto> CreateAsync(OrderDto entity);

        Task<IEnumerable<OrderInformation>> GetOrdersByUserAsync(string userId);
    }
}
