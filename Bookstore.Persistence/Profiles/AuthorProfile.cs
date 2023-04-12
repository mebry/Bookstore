using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Persistence.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>()
             .ReverseMap();
        }
    }
}
