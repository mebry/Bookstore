using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IOrderDetailRepository 
    {
        Task CreateAsync(OrderDetailDto orderDetailDto);

        Task CreateRangeAsync(IEnumerable<OrderDetailDto> orderDetailDto);
    }
}
