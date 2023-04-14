using AutoMapper;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateAsync(AuthorDto entity)
        {
            var newEntity = _mapper.Map<Author>(entity);

            await _context.Authors.AddAsync(newEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(newEntity);
        }

        /*Если строки с указанным вами первичным ключом не существует, EF Core генерирует исключение
        DbUpdateConcurrencyException, сообщая, что ничего не удалено*/
        public async Task DeleteAsync(int id)
        {
            var entity = new Author { Id = id };

            _context.Authors.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var dataList = await _context.Authors.AsNoTracking().ToArrayAsync();

            var mappedList = _mapper.Map<IEnumerable<AuthorDto>>(dataList);

            return mappedList;
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Authors
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);

            var mappedEntity = _mapper.Map<AuthorDto>(entity);

            return mappedEntity;
        }

        public async Task<IEnumerable<AuthorDto>> GetSoftDeletedAuthorsAsync()
        {
            var dataList = await _context.Authors
                .IgnoreQueryFilters()
                .Where(e => e.IsDeleted)
                .ToListAsync();

            var mappedList = _mapper.Map<IEnumerable<AuthorDto>>(dataList);

            return mappedList;
        }

        public async Task<IEnumerable<AuthorDto>> SearchByLastNameAsync(string authorName)
        {
            var dataList = await _context.Authors
                .AsNoTracking()
                .Where(e => e.LastName.ToLower()
                .Contains(authorName.ToLower()))
                .ToListAsync();

            var mappedList = _mapper.Map<IEnumerable<AuthorDto>>(dataList);

            return mappedList;
        }

        public async Task<bool> SetSoftDeleteAsync(int id)
        {
            var foundEntity = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (foundEntity is null)
            {
                throw new NotFoundException(nameof(Author), id);
            }

            foundEntity.IsDeleted = !foundEntity.IsDeleted;

            await _context.SaveChangesAsync();

            return foundEntity.IsDeleted;
        }

        public async Task<AuthorDto> UpdateAsync(AuthorDto entity)
        {
            var foundEntity = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (foundEntity is null)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }

            _mapper.Map(entity, foundEntity);

            _context.Authors.Update(foundEntity);

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<AuthorDto>(foundEntity);

            return mappedEntity;
        }
    }
}
