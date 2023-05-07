using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Behaviours
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository,
             IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Response<IEnumerable<OrderInformation>>> GetOrdersByUserAsync(string userId)
        {
            var response = new Response<IEnumerable<OrderInformation>>();

            try
            {
                if (userId is null)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Id can't be null.";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var orders = await _orderRepository.GetOrdersByUserAsync(userId);

                response.Data = orders;
                response.Description = "Orders were found successfully.";
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

        public async Task<Response<bool>> CreateOrderAsync(string userId)
        {
            var response = new Response<bool>();
            try
            {
                if (userId is null)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Id can't be null.";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var isFoundCart = await _cartRepository.IsExistUserCartAsync(userId);

                if (!isFoundCart)
                {
                    response.Data = false;
                    response.Description = "Can't find the user cart.";
                    response.StatusCode = StatusCode.NotFound;

                    return response;
                }

                var userCartDetails = await _cartDetailRepository.GetCartDetailsByUserIdAsync(userId);

                if (userCartDetails is null)
                {
                    response.Data = false;
                    response.Description = "Can't find cart details.";
                    response.StatusCode = StatusCode.NotFound;

                    return response;
                }

                var order = await _orderRepository.CreateAsync(new OrderDto
                {
                    UserId = userId,
                    CreatedAt = DateTime.Now
                });

                var orderDetailList = new List<OrderDetailDto>();

                foreach (var item in userCartDetails)
                {
                    orderDetailList.Add(new OrderDetailDto()
                    {
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        BookId = item.BookId
                    });
                }

                await _orderDetailRepository.CreateRangeAsync(orderDetailList);

                var cart = await _cartRepository.GetByUserIdAsync(userId);

                await _cartRepository.ResetCartAsync(cart.Id);
                response.Data = true;
                response.Description = "The order was created successfully";
                response.StatusCode = StatusCode.OK;

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
    }
}
