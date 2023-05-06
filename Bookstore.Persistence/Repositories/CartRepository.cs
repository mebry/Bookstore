using AutoMapper;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDto> CreateAsync(CartDto entity)
        {
            var mappedCart = _mapper.Map<Cart>(entity);

            await _context.Carts.AddAsync(mappedCart);

            await _context.SaveChangesAsync();

            var cart = _mapper.Map<CartDto>(mappedCart);

            return cart;
        }

        public async Task<CartDto> GetByUserId(string userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(i => i.UserId == userId);

            var mappedCart = _mapper.Map<CartDto>(cart);

            return mappedCart;
        }

        public async Task<bool> IsExistUserCart(string userId)
        {
            var isFound = await _context.Carts.AnyAsync(c => c.UserId == userId);

            return isFound;
        }
    }
}
