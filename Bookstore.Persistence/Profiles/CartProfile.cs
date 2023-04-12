using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Entities;

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
