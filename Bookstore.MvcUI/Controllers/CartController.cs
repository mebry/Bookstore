using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.MvcUI.Models;
using Bookstore.MvcUI.ViewModels.Incoming;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.MvcUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICurrentUserService currentUserService, ICartService cartService, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _cartService = cartService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _cartService.GetCartDetailsByUserIdAsync(_currentUserService.UserId);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Book",
                       Description = result.Description
                   });
            }
            var mappedDetails = _mapper.Map<List<UserCartDetails>>(result.Data);

            return View(mappedDetails);
        }
        public async Task<IActionResult> AddItem(int id)
        {
            var result = await _cartService.AddCartDetailAsync(_currentUserService.UserId, id, 1);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Cart",
                       Description = result.Description
                   });
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var result = await _cartService.DeleteCartDetailAsync(_currentUserService.UserId, id, 1);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Cart",
                       Description = result.Description
                   });
            }

            return RedirectToAction("Index");
        }
    }
}
