using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Common.Behaviours
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<BookDto>> CreateAsync(BookDto model)
        {
            var response = new Response<BookDto>();

            try
            {
                if (model is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var book = await _bookRepository.CreateAsync(model);

                response.Data = book;
                response.Description = "The book was created";
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

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id < 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _bookRepository.DeleteAsync(id);

                response.Data = true;
                response.Description = "The book was removed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

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

        public async Task<Response<IEnumerable<BookDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                var books = await _bookRepository.GetAllAsync();

                response.Data = books;
                response.Description = "The book was received successfully";
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

        public async Task<Response<IEnumerable<BookPreview>>> GetBookPreviewsAsync()
        {
            var response = new Response<IEnumerable<BookPreview>>();
            try
            {
                var books = await _bookRepository.GetBookPreviewsAsync();

                response.Data = books;
                response.Description = "The book was received successfully";
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

        public async Task<Response<BookDto>> GetByIdAsync(int id)
        {
            var response = new Response<BookDto>();
            try
            {
                if (id < 0)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var entity = await _bookRepository.GetByIdAsync(id);

                response.Data = entity;
                response.Description = "The book was received";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

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

        public async Task<Response<IEnumerable<BookDto>>> GetSoftDeletedBooksAsync()
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                var authors = await _bookRepository.GetSoftDeletedBooksAsync();

                response.Data = authors;
                response.Description = "The soft removed books have been received";
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

        public async Task<Response<IEnumerable<BookDto>>> SearchByNameAsync(string name)
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    response.Data = null;
                    response.Description = "The name can't be null or empty";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var books = await _bookRepository.SearchByNameAsync(name);

                response.Data = books;
                response.Description = "The book was received successfully";
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

        public async Task<Response<bool>> SetSoftDeleteAsync(int id)
        {
            var response = new Response<bool>();

            try
            {
                if (id < 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                bool softStatus = await _bookRepository.SetSoftDeleteAsync(id);

                response.Data = softStatus;
                response.Description = "Soft deleted property was changed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (NotFoundException ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

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

        public async Task<Response<BookDto>> UpdateAsync(BookDto model)
        {
            var response = new Response<BookDto>();
            try
            {
                if (model is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var entity = await _bookRepository.UpdateAsync(model);

                response.Data = entity;
                response.Description = "The book was updated";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

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
