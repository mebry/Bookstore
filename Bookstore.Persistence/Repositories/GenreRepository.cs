using AutoMapper;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenreRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenreDto> CreateAsync(GenreDto entity)
        {
            var newEntity = _mapper.Map<Genre>(entity);

            await _context.Genres.AddAsync(newEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<GenreDto>(newEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = new Genre { Id = id };

            _context.Genres.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var dataList = await _context.Genres.AsNoTracking().ToArrayAsync();

            var mappedList = _mapper.Map<IEnumerable<GenreDto>>(dataList);

            return mappedList;
        }

        public async Task<GenreDto> GetByIdAsync(int id)
        {
            var entity = await _context.Genres
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);

            var mappedEntity = _mapper.Map<GenreDto>(entity);

            return mappedEntity;
        }

        public async Task<GenreDto> UpdateAsync(GenreDto entity)
        {
            var foundEntity = await _context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (foundEntity is null)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }

            _mapper.Map(entity, foundEntity);

            _context.Genres.Update(foundEntity);

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<GenreDto>(foundEntity);

            return mappedEntity;
        }
    }
}
