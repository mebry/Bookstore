using Bookstore.Infrastructure.Persistance.DataContext;
using Bookstore.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookstore.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookstoreDbContext _bookstoreDbContext;

        public HomeController(ILogger<HomeController> logger,BookstoreDbContext bookstoreDbContext)
        {
            _logger = logger;
            _bookstoreDbContext = bookstoreDbContext;
        }

        public IActionResult Index()
        {
            _bookstoreDbContext.Genres.ToArray();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}