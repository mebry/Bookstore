using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IGenreService genreService,
            IAuthorService authorService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookDetails = await _bookService.GetByIdAsync(id);

            var IsFound = CheckStatusCode(bookDetails);

            return IsFound is not null ? IsFound : Ok(bookDetails);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetByIdDetails(int id)
        {
            var bookDetails = await _bookService.GetBookDetailsAsync(id);

            var IsFound = CheckStatusCode(bookDetails);

            return IsFound is not null ? IsFound : Ok(bookDetails);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetBookPreviewsAsync();

            var IsFound = CheckStatusCode(books);

            return IsFound is not null ? IsFound : Ok(books);
        }

        [HttpPut("UpdateDetails/{id}")]
        public async Task<IActionResult> Edit(int id, BookWithAuthors bookForUpdate)
        {
            if (id != bookForUpdate.Id)
            {
                return BadRequest();
            }

            var result = await _bookService.UpdateBookDetailsAsync(bookForUpdate);

            var IsFound = CheckStatusCode(result);

            return IsFound is not null ? IsFound:Ok(bookForUpdate);
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Edit(int id, BookDto bookForUpdate)
        {
            if (id != bookForUpdate.Id)
            {
                return BadRequest();
            }

            var result = await _bookService.UpdateAsync(bookForUpdate);

            var IsFound = CheckStatusCode(result);

            return IsFound is not null ? IsFound : Ok(bookForUpdate);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(BookWithAuthors bookForCreation)
        {
            var result = await _bookService.CreatBookWithAuthorsAsync(bookForCreation);

            var IsFound = CheckStatusCode(result);

            return IsFound is not null ? IsFound : Ok(result.Description);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.SetSoftDeleteAsync(id);

            var IsFound = CheckStatusCode(result);

            return IsFound is not null ? IsFound : Ok(result.Description);
        }

        [HttpGet("Search/{bookName}")]
        public async Task<IActionResult> Search(string bookName)
        {
            var result = await _bookService.SearchByNameAsync(bookName);

            var IsFound = CheckStatusCode(result);

            return IsFound is not null ? IsFound : Ok(result.Data);
        }

        private IActionResult CheckStatusCode<T>(Response<T> response)
        {
            if (response.StatusCode == Domain.Enums.StatusCode.NotFound)
            {
                return NotFound(response.Description);
            }
            else if (response.StatusCode == Domain.Enums.StatusCode.BadRequest)
            {
                return BadRequest(response.Description);
            }
            else if (response.StatusCode == Domain.Enums.StatusCode.InternalServerError)
            {
                return Problem(response.Description, null, (int)response.StatusCode);
            }

            return null; // null, если статус кода не требует специальной обработки
        }
    }
}