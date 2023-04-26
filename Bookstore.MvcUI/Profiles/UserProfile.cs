using AutoMapper;
using Bookstore.Application.Shared.Identity;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Incoming;
using Bookstore.MvcUI.ViewModels.Outgoing;

namespace Bookstore.MvcUI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForSignUp, ApplicationUser>().ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));
        }
    }
}
