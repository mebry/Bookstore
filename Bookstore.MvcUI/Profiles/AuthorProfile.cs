using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Incoming;

namespace Bookstore.MvcUI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, AuthorForDisplay>();
            CreateMap<AuthorForCreation, AuthorDto>();
            CreateMap<AuthorForUpdate, AuthorDto>().ReverseMap();
        }
    }
}
