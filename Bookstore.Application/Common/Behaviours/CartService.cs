using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Common.Behaviours
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;

        public CartService(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
        }

        public async Task<Response<bool>> AddCartDetailAsync(string userId, int bookId, int quantity)
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

                if (bookId <= 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                if (quantity <= 0)
                {
                    response.Data = false;
                    response.Description = "Quantity must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var isFoundCart = await _cartRepository.IsExistUserCart(userId);

                if (!isFoundCart)
                {
                    var cart = await _cartRepository.CreateAsync(new CartDto() { UserId = userId });

                    await _cartDetailRepository.CreateAsync(new CartDetailDto { BookId = bookId, Quantity = quantity });

                }
                else
                {
                    var foundCart = await _cartRepository.GetByUserId(userId);

                    var isFoundCartDetails = await _cartDetailRepository.IsExistCartDetail(foundCart.Id, bookId);

                    if (!isFoundCartDetails)
                    {
                        await _cartDetailRepository.CreateAsync(new CartDetailDto { CartId = foundCart.Id, BookId = bookId, Quantity = quantity });
                    }
                    else
                    {
                        await _cartDetailRepository.AddCartDetailAsync(foundCart.Id, bookId, quantity);
                    }
                }

                response.Data = true;
                response.Description = "The cart detail was added successfully";
                response.StatusCode = StatusCode.NotFound;

                return response;

            }
            catch (DbUpdateConcurrencyException ex)
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

        public async Task<Response<bool>> DeleteCartDetailAsync(string userId, int bookId, int quantity)
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

                if (bookId <= 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                if (quantity <= 0)
                {
                    response.Data = false;
                    response.Description = "Quantity must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var foundCart = await _cartRepository.GetByUserId(userId);

                if (foundCart is not null)
                {
                    var isFoundCartDetail = await _cartDetailRepository.IsExistCartDetail(foundCart.Id, bookId);

                    if (isFoundCartDetail)
                    {
                        await _cartDetailRepository.DeleteCartDetailAsync(foundCart.Id, bookId, quantity);

                        response.Data = true;
                        response.Description = "Cart not found";
                        response.StatusCode = StatusCode.OK;

                        return response;
                    }

                    response.Data = false;
                    response.Description = "Information about the cart detail was not found";
                    response.StatusCode = StatusCode.NotFound;

                    return response;

                }
                else
                {
                    response.Data = false;
                    response.Description = "Cart not found";
                    response.StatusCode = StatusCode.NotFound;

                    return response;
                }
            }
            catch (DbUpdateConcurrencyException ex)
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

        public async Task<Response<IEnumerable<CartDetailsPreview>>> GetCartDetailsByUserIdAsync(string userId)
        {
            var response = new Response<IEnumerable<CartDetailsPreview>>();
            try
            {
                if (userId is null)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Id can't be null.";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var cartDetails = await _cartDetailRepository.GetCartDetailsByUserIdAsync(userId);

                response.Data = cartDetails;
                response.Description = "Cart details was found successfully.";
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
    }
}
