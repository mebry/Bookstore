using AutoMapper;
using Bookstore.Application.Shared.Models;
using Bookstore.Domain.Dtos;

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