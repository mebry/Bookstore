using Bookstore.MvcUI.Models;
using Bookstore.Persistence.DataContext;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}