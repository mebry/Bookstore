using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.MvcUI.Models;
using Bookstore.MvcUI.ViewModels.Outgoing;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.MvcUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(ICurrentUserService currentUserService, IOrderService orderService, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _orderService = orderService;
            
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetOrdersByUserAsync(_currentUserService.UserId);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Book",
                       Description = result.Description
                   });
            }
            var mappedDetails = _mapper.Map<List<OrderInformationForDisplay>>(result.Data);

            return View(mappedDetails);
        }

        public async Task<IActionResult> CreateOrder()
        {
            var result = await _orderService.CreateOrderAsync(_currentUserService.UserId);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Cart",
                       Description = result.Description
                   });
            }

            return View("Success", "Order");
        }

    }
}
