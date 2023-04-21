using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;
using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Behaviours
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _authorBookRepository;

        public AuthorBookService(IAuthorBookRepository authorBookRepository)
        {
            _authorBookRepository = authorBookRepository;
        }

        public async Task<Response<bool>> CreateAsync(AuthorBookDto entity)
        {
            var response = new Response<bool>();

            try
            {
                if (entity is null)
                {
                    response.Data = false;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _authorBookRepository.CreateAsync(entity);

                response.Data = true;
                response.Description = "The book with an author was created";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<Response<bool>> CreateRangeAsync(IEnumerable<AuthorBookDto> authorBooks)
        {
            var response = new Response<bool>();

            try
            {
                if (authorBooks is null && authorBooks.Count() == 0)
                {
                    response.Data = false;
                    response.Description = "list can't be null or empty";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _authorBookRepository.CreateRangeAsync(authorBooks);

                response.Data = true;
                response.Description = "The books with authors were created";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<Response<bool>> DeleteAsync(AuthorBookDto entity)
        {
            var response = new Response<bool>();

            try
            {
                if (entity is null)
                {
                    response.Data = false;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _authorBookRepository.DeleteAsync(entity);

                response.Data = true;
                response.Description = "The book with an author was removed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<Response<bool>> DeleteRangeAsync(IEnumerable<AuthorBookDto> authorBooks)
        {
            var response = new Response<bool>();

            try
            {
                if (authorBooks is null && authorBooks.Count() == 0)
                {
                    response.Data = false;
                    response.Description = "List can't be null or empty";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _authorBookRepository.DeleteRangeAsync(authorBooks);

                response.Data = true;
                response.Description = "The books with authors were removed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<Response<IEnumerable<AuthorBookDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<AuthorBookDto>>();

            try
            {
                var result = await _authorBookRepository.GetAllAsync();

                response.Data = result;
                response.Description = "The books with authors were got";
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

        public async Task<Response<IEnumerable<AuthorBookDto>>> GetByBookIdAsync(int bookId)
        {
            var response = new Response<IEnumerable<AuthorBookDto>>();

            try
            {
                if (bookId <= 0)
                {
                    response.Data = null;
                    response.Description = "the id can't be below 1";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var result = await _authorBookRepository.GetByBookIdAsync(bookId);

                response.Data = result;
                response.Description = "The books with authors were got";
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
    }
}
