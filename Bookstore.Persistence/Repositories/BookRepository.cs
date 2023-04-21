using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookstore.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateAsync(BookDto entity)
        {
            var newEntity = _mapper.Map<Book>(entity);

            await _context.Books.AddAsync(newEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(newEntity);
        }

        /*Если строки с указанным вами первичным ключом не существует, EF Core генерирует исключение
        DbUpdateConcurrencyException, сообщая, что ничего не удалено*/
        public async Task DeleteAsync(int id)
        {
            var entity = new Book { Id = id };

            _context.Books.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var dataList = await _context.Books.AsNoTracking().ToArrayAsync();

            var mappedList = _mapper.Map<IEnumerable<BookDto>>(dataList);

            return mappedList;
        }

        public async Task<BookDetails> GetBookDetailsAsync(int id)
        {
            var books = await _context.Books
               .AsNoTrackingWithIdentityResolution()
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Genre)
               .ProjectTo<BookDetails>(_mapper.ConfigurationProvider)
               .SingleAsync(x => x.Id == id);

            return books;
        }

        /// <summary>
        /// AsNoTrackingWithIdentityResolution -as a rule, faster 
        ///a normal query, but slower than the same query with AsNoTrack ing. 
        ///The improvement is that relationships with database objects are represented correctly, 
        ///instances of entity classes with the same primary key are 
        ///represented by one object that corresponds to one row in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookPreview>> GetBookPreviewsAsync()
        {
            var books = await _context.Books
                .AsNoTrackingWithIdentityResolution()
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Genre)
                .ProjectTo<BookPreview>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByGenreAsync(List<int> genresId)
        {
            var dataList = await _context.Books
                .AsNoTracking()
                .Where(e => genresId.Contains(e.Id))
                .ToListAsync();

            var mappedList = _mapper.Map<IEnumerable<BookDto>>(dataList);

            return mappedList;
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Books
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);

            var mappedEntity = _mapper.Map<BookDto>(entity);

            return mappedEntity;
        }

        public async Task<IEnumerable<BookDto>> GetSoftDeletedBooksAsync()
        {
            var dataList = await _context.Books
                .IgnoreQueryFilters()
                .Where(e => e.IsDeleted)
                .ToListAsync();

            var mappedList = _mapper.Map<IEnumerable<BookDto>>(dataList);

            return mappedList;
        }

        public async Task<IEnumerable<BookDto>> SearchByNameAsync(string name)
        {
            var dataList = await _context.Books
                .AsNoTracking()
                .Where(e => e.Name.ToLower()
                .Contains(name.ToLower()))
                .ToListAsync();

            var mappedList = _mapper.Map<IEnumerable<BookDto>>(dataList);

            return mappedList;
        }

        public async Task<bool> SetSoftDeleteAsync(int id)
        {
            var foundEntity = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (foundEntity is null)
            {
                throw new NotFoundException(nameof(Book), id);
            }

            foundEntity.IsDeleted = !foundEntity.IsDeleted;

            await _context.SaveChangesAsync();

            return foundEntity.IsDeleted;
        }

        public async Task<BookDto> UpdateAsync(BookDto entity)
        {
            var foundEntity = await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (foundEntity is null)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }

            _mapper.Map(entity, foundEntity);

            _context.Books.Update(foundEntity);

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<BookDto>(foundEntity);

            return mappedEntity;
        }
    }
}
