using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class CartDetailRepository : ICartDetailRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartDetailRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CartDetailDto cartDetailDto)
        {
            var mappedCartDetails = _mapper.Map<CartDetail>(cartDetailDto);

            await _context.CartDetails.AddAsync(mappedCartDetails);

            await _context.SaveChangesAsync();
        }

        public async Task AddCartDetailAsync(int cartId, int bookId, int quantity)
        {
            var cartDetail = await _context.CartDetails
                .SingleAsync(i => i.CartId == cartId && i.BookId == bookId);

            cartDetail.Quantity += quantity;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistCartDetail(int cartId, int bookId)
        {
            var isFound = await _context.CartDetails.AsNoTracking()
                .AnyAsync(i => i.CartId == cartId && i.BookId == bookId);

            return isFound;
        }

        public async Task<IEnumerable<CartDetailsPreview>> GetCartDetailsByUserIdAsync(string userId)
        {
            var cartDetails = await _context.CartDetails
                .AsNoTracking()
                .Include(b => b.Cart)
                .Include(b => b.Book)
                .Where(i => i.Cart.UserId == userId)
                .ProjectTo<CartDetailsPreview>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return cartDetails;
        }

        public async Task DeleteCartDetailAsync(int cartId, int bookId, int quantity)
        {
            var cartDetail = await _context.CartDetails
                .SingleAsync(i => i.CartId == cartId && i.BookId == bookId);

            cartDetail.Quantity -= quantity;

            if (cartDetail.Quantity <= 0)
            {
                _context.CartDetails.Remove(cartDetail);
            }

            await _context.SaveChangesAsync();
        }
    }
}
