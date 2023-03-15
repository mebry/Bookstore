using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Domain.Entities.Book, Models.Book>()
             .ReverseMap();
        }
    }
}
