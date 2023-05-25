using AutoMapper;
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
        private readonly IAuthorBookService _authorBookService;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IAuthorBookService authorBookService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorBookService = authorBookService;
            _mapper = mapper;
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
            catch (DbUpdateException ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.BadRequest;

                return response;
            }
            catch (System.InvalidOperationException ex)
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

        public async Task<Response<BookDetails>> GetBookDetailsAsync(int id)
        {
            var response = new Response<BookDetails>();
            try
            {
                if (id < 0)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var entity = await _bookRepository.GetBookDetailsAsync(id);

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
            catch (System.InvalidOperationException ex)
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
            catch (System.InvalidOperationException ex)
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

        public async Task<Response<IEnumerable<BookPreview>>> SearchByNameAsync(string name)
        {
            var response = new Response<IEnumerable<BookPreview>>();
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
            catch (System.InvalidOperationException ex)
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

        public async Task<Response<BookWithAuthors>> CreatBookWithAuthorsAsync(BookWithAuthors bookWithAuthors)
        {
            var response = new Response<BookWithAuthors>();
            try
            {
                if (bookWithAuthors is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var book = _mapper.Map<BookDto>(bookWithAuthors);

                var createdBook = await _bookRepository.CreateAsync(book);

                if (createdBook is null)
                {
                    response.Data = null;
                    response.Description = "Can't create a book";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var authorBookList = new List<AuthorBookDto>();
                foreach (var authorId in bookWithAuthors.AuthorsId)
                {
                    authorBookList.Add(new AuthorBookDto()
                    {
                        AuthorId = authorId,
                        BookId = createdBook.Id
                    });
                }

                await _authorBookService.CreateRangeAsync(authorBookList);

                response.Data = bookWithAuthors;
                response.Description = "The book with authors was successfully created";
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

        public async Task<Response<BookWithAuthors>> GetBookWithAuthors(int id)
        {
            var response = new Response<BookWithAuthors>();
            try
            {
                if (id < 0)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var book = await _bookRepository.GetByIdAsync(id);

                var bookAuthors = await _authorBookService.GetByBookIdAsync(id);

                var mappedBook = _mapper.Map<BookWithAuthors>(book);

                if (bookAuthors.StatusCode != StatusCode.OK)
                {
                    response.Data = null;
                    response.Description = bookAuthors.Description;
                    response.StatusCode = bookAuthors.StatusCode;

                    return response;
                }

                var listIds = new List<int>();

                bookAuthors.Data.ToList().ForEach(i => listIds.Add(i.AuthorId));

                mappedBook.AuthorsId = listIds;

                response.Data=mappedBook;
                response.Description = "Data was received";
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

        public async Task<Response<BookWithAuthors>> UpdateBookDetailsAsync(BookWithAuthors bookWithAuthors)
        {
            var response = new Response<BookWithAuthors>();
            try
            {
                if (bookWithAuthors is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var book = _mapper.Map<BookDto>(bookWithAuthors);


                var updatedBook = await _bookRepository.UpdateAsync(book);

                var result = await _authorBookService.GetByBookIdAsync(updatedBook.Id);

                if (result.StatusCode != StatusCode.OK)
                {
                    response.Data = null;
                    response.Description = result.Description;
                    response.StatusCode = result.StatusCode;

                    return response;
                }

                var bookAndAuthors = result.Data;

                await _authorBookService.DeleteRangeAsync(bookAndAuthors);

                var authorBookList = new List<AuthorBookDto>();
                foreach (var authorId in bookWithAuthors.AuthorsId)
                {
                    authorBookList.Add(new AuthorBookDto()
                    {
                        AuthorId = authorId,
                        BookId = updatedBook.Id
                    });
                }

                await _authorBookService.CreateRangeAsync(authorBookList);

                response.Data = bookWithAuthors;
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
            catch (System.InvalidOperationException ex)
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
