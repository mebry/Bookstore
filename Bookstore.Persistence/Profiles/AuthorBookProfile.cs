using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class AuthorBookProfile : Profile
    {
        public AuthorBookProfile()
        {
            CreateMap<Domain.Entities.AuthorBookDto, Models.AuthorBook>()
             .ReverseMap();
        }
    }
}
