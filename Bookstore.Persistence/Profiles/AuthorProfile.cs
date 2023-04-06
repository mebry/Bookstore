using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Domain.Entities.AuthorBookDto, Models.AuthorBook>()
             .ReverseMap();
        }
    }
}
