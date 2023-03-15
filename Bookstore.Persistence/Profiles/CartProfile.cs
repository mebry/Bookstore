using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Domain.Entities.Cart, Models.Cart>()
             .ReverseMap();
        }
    }
}
