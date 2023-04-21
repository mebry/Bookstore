using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorBookRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(AuthorBookDto entity)
        {
            var newEntity = _mapper.Map<AuthorBook>(entity);

            await _context.AuthorsBooks.AddAsync(newEntity);

            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<AuthorBookDto> authorBooks)
        {
            var newEntities = _mapper.Map<IEnumerable<AuthorBook>>(authorBooks);

            await _context.AuthorsBooks.AddRangeAsync(newEntities);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AuthorBookDto entity)
        {
            var entityForRemove = _mapper.Map<AuthorBook>(entity);

            _context.AuthorsBooks.Remove(entityForRemove);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<AuthorBookDto> authorBooks)
        {
            var entitiesForRemove = _mapper.Map<IEnumerable<AuthorBook>>(authorBooks);

            _context.AuthorsBooks.RemoveRange(entitiesForRemove);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorBookDto>> GetAllAsync()
        {
            var dataList = await _context.AuthorsBooks.AsNoTracking().ToArrayAsync();

            var mappedList = _mapper.Map<IEnumerable<AuthorBookDto>>(dataList);

            return mappedList;
        }

        public async Task<IEnumerable<AuthorBookDto>> GetByBookIdAsync(int bookId)
        {
            var dataList = await _context.AuthorsBooks
                .AsNoTracking()
                .Where(e => e.BookId == bookId)
                .ProjectTo<AuthorBookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return dataList;
        }
    }
}
