using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
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


    }
}
