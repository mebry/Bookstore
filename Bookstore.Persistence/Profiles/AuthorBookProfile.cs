using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

namespace Bookstore.Persistence.Profiles
{
    public class AuthorBookProfile : Profile
    {
        public AuthorBookProfile()
        {
            CreateMap<AuthorBookDto, AuthorBook>()
             .ReverseMap();
        }
    }
}
