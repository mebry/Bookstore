using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class CartDetailProfile : Profile
    {
        public CartDetailProfile()
        {
            CreateMap<CartDetailDto, CartDetail>()
             .ReverseMap();
        }
    }
}
