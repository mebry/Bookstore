using AutoMapper;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateAsync(OrderDto entity)
        {
            var mappedOrder = _mapper.Map<Order>(entity);

            await _context.Orders.AddAsync(mappedOrder);

            await _context.SaveChangesAsync();

            var order = _mapper.Map<OrderDto>(mappedOrder);

            return order;

        }

        public async Task<IEnumerable<OrderInformation>> GetOrdersByUserAsync(string userId)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .Where(o => o.UserId == userId)
            .ToListAsync();

            var mappedOrders = _mapper.Map<List<OrderInformation>>(orders);

            return mappedOrders;
        }
    }
}
