using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Entities;

namespace Bookstore.Persistence.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreDto, Genre>()
             .ReverseMap();
        }
    }
}