using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
             .ReverseMap();

            CreateMap<Book, BookPreview>()
            .ForMember(dest => dest.Genre, 
                opt => opt.MapFrom(src => src.GenreId))
             .ForMember(dest => dest.Authors, 
                opt => opt.MapFrom(src => src.AuthorBooks.Select(ab => $"{ab.Author.FirstName} {ab.Author.LastName}")));
        }
    }
}
