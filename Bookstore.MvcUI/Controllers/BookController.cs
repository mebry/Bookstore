using AutoMapper;
using Bookstore.Application.Common.Behaviours;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.MvcUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBookPreviewsAsync();

            var mappedAuthors = _mapper.Map<IEnumerable<BookForDisplay>>(books.Data);

            return View(mappedAuthors);
        }

    }
}
