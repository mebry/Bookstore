using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain;

namespace Bookstore.Persistence.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Entities.OrderDto, Order>()
             .ReverseMap();
        }
    }
}
