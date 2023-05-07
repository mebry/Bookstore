using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class CartDetailProfile : Profile
    {
        public CartDetailProfile()
        {
            CreateMap<CartDetail, CartDetailsPreview>()
                .ForMember(dest => dest.UnitPrice,
                    opt => opt.MapFrom(src => src.Book.Price))
                .ForMember(dest => dest.BookImageURL,
                    opt => opt.MapFrom(src => src.Book.ImageURL))
                .ForMember(dest => dest.BookName,
                    opt => opt.MapFrom(src => src.Book.Name));

            CreateMap<CartDetail, CartDetailDto>()
                .ReverseMap();
        }
    }
}
