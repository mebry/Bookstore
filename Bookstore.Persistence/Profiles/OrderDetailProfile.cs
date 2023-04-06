using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<Domain.Entities.OrderDetailDto, Models.OrderDetail>()
             .ReverseMap();
        }
    }
}
