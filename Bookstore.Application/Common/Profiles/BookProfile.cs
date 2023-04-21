using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bookstore.Application.Common.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, BookWithAuthors>()
             .ReverseMap();
        }
    }
}
