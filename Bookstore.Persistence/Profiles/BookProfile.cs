using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Persistence.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
             .ReverseMap();
        }
    }
}
