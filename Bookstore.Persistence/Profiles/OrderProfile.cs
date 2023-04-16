using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain;

namespace Bookstore.Persistence.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Dtos.OrderDto, Order>()
             .ReverseMap();
        }
    }
}
