using AutoMapper;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.ViewModels.Outgoing;

namespace Bookstore.MvcUI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookPreview, BookForDisplay>();
            //CreateMap<AuthorForCreation, AuthorDto>();
            //CreateMap<AuthorForUpdate, AuthorDto>().ReverseMap();
        }
    }
}
