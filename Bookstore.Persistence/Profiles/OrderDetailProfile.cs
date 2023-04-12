using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Persistence.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailDto, OrderDetail>()
             .ReverseMap();
        }
    }
}
