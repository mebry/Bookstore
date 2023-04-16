using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

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
