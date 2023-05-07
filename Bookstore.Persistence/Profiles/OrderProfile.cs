using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
             .ReverseMap();

            CreateMap<Order, OrderInformation>()
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src => src.OrderDetails.Sum(od => od.Book.Price * od.Quantity)));
        }
    }
}
