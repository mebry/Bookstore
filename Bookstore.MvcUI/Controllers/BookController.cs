using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Shared.Identity;
using Bookstore.Domain.DisplayModels;
using Bookstore.MvcUI.Models;
using Bookstore.MvcUI.ViewModels.Incoming;
using Bookstore.MvcUI.ViewModels.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.MvcUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IGenreService genreService,
            IAuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBookPreviewsAsync();

            var mappedBooks = _mapper.Map<IEnumerable<BookForDisplay>>(books.Data);

            return View(mappedBooks);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _bookService.GetBookDetailsAsync(id);

            if (bookDetails.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = bookDetails.Description
                    });
            }

            var mappedBook = _mapper.Map<BookDetailsForDisplay>(bookDetails.Data);

            return View(mappedBook);
        }
        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var bookForUpdate = await _bookService.GetBookWithAuthors(id);

            if (bookForUpdate.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = bookForUpdate.Description
                    });
            }

            var book = _mapper.Map<BookForUpdate>(bookForUpdate.Data);

            var genres = await _genreService.GetAllAsync();
            var author = await _authorService.GetAllAsync();

            if (genres.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = genres.Description
                    });
            }

            if (author.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = author.Description
                    });
            }

            ViewBag.Genres = new SelectList(genres.Data, "Id", "Name");
            ViewBag.Authors = new SelectList(author.Data, "Id", "LastName");

            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Edit(int id, BookForUpdate bookForUpdate)
        {
            if (!ModelState.IsValid)
            {
                var genres = await _genreService.GetAllAsync();
                var author = await _authorService.GetAllAsync();
                ViewBag.Genres = new SelectList(genres.Data, "Id", "Name");
                ViewBag.Authors = new SelectList(author.Data, "Id", "LastName");

                return View(bookForUpdate);
            }

            if (id != bookForUpdate.Id)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = "Ids don't match"
                    });
            }

            var mappedBook = _mapper.Map<BookWithAuthors>(bookForUpdate);

            await _bookService.UpdateBookDetailsAsync(mappedBook);

            return View("Success", "Book");
        }

        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Create()
        {
            var genres = await _genreService.GetAllAsync();
            var author = await _authorService.GetAllAsync();

            if (genres.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = genres.Description
                    });
            }

            if (author.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Book",
                        Description = author.Description
                    });
            }

            ViewBag.Genres = new SelectList(genres.Data, "Id", "Name");
            ViewBag.Authors = new SelectList(author.Data, "Id", "LastName");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Create(BookForCreation bookForCreation)
        {

            if (!ModelState.IsValid)
            {
                var genres = await _genreService.GetAllAsync();
                var author = await _authorService.GetAllAsync();
                ViewBag.Genres = new SelectList(genres.Data, "Id", "Name");
                ViewBag.Authors = new SelectList(author.Data, "Id", "LastName");

                return View(bookForCreation);
            }

            var mappedBook = _mapper.Map<BookWithAuthors>(bookForCreation);

            var result = await _bookService.CreatBookWithAuthorsAsync(mappedBook);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Book",
                       Description = result.Description
                   });
            }

            return View("Success", "Book");
        }


        public async Task<IActionResult> Search(string bookName)
        {
            if (string.IsNullOrWhiteSpace(bookName))
            {
                return PartialView("_BookList", new List<BookForDisplay>());
            }

            var result = await _bookService.SearchByNameAsync(bookName);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Book",
                       Description = result.Description
                   });
            }
            var mappedBooks = _mapper.Map<IEnumerable<BookForDisplay>>(result.Data);

            return PartialView("_BookList", mappedBooks);
        }

        public async Task<IActionResult> ShowAllWithPartialView()
        {
            var books = await _bookService.GetBookPreviewsAsync();

            var mappedBooks = _mapper.Map<IEnumerable<BookForDisplay>>(books.Data);

            return PartialView("_BookList", mappedBooks);
        }

        public IActionResult ShowDocumentation()
        {
            return View();
        }
    }
}
