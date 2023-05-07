using AutoMapper;
using Bookstore.Application.Shared.Identity;
using Bookstore.Domain.DisplayModels;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Incoming;
using Bookstore.MvcUI.ViewModels.Outgoing;

namespace Bookstore.MvcUI.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDetailsPreview, UserCartDetails>();
        }
    }
}
