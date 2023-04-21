using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Domain.Dtos;
using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Behaviours
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<Response<GenreDto>> CreateAsync(GenreDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<GenreDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<GenreDto>>();
            try
            {
                var genres = await _genreRepository.GetAllAsync();

                response.Data = genres;
                response.Description = "The genres were received successfully";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public Task<Response<GenreDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<GenreDto>> UpdateAsync(GenreDto model)
        {
            throw new NotImplementedException();
        }
    }
}
