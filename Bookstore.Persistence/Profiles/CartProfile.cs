using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>()
             .ReverseMap();
        }
    }
}
