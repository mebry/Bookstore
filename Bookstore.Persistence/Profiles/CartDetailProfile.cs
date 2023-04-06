using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class CartDetailProfile : Profile
    {
        public CartDetailProfile()
        {
            CreateMap<Domain.Entities.CartDetailDto, Models.CartDetail>()
             .ReverseMap();
        }
    }
}
