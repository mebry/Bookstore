using AutoMapper;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Incoming;
using Bookstore.MvcUI.ViewModels.Outgoing;

namespace Bookstore.MvcUI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookPreview, BookForDisplay>();

            CreateMap<BookDetails, BookDetailsForDisplay>()
            .ForMember(dest => dest.Authors,
                opt => opt.MapFrom(src => src.Authors
                    .Select(a => new AuthorForDisplay
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        ProfilePictureURL = a.ProfilePictureURL
                    })));

            CreateMap<BookForCreation, BookWithAuthors>()
                .ReverseMap();

            //CreateMap<BookDetails, BookForCreation>();
            CreateMap<BookDetails, BookForUpdate>();

            CreateMap<BookForUpdate, BookWithAuthors>()
                .ReverseMap();
        }
    }
}
