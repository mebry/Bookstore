using AutoMapper;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderDetailDto orderDetailDto)
        {
            var mappedOrderDetails = _mapper.Map<OrderDetail>(orderDetailDto);

            await _context.OrderDetails.AddAsync(mappedOrderDetails);

            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<OrderDetailDto> orderDetailDto)
        {
            var mappedOrderDetails = _mapper.Map<IEnumerable<OrderDetail>>(orderDetailDto);

            await _context.OrderDetails.AddRangeAsync(mappedOrderDetails);

            await _context.SaveChangesAsync();
        }
    }
}
