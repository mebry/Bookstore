using AutoMapper;
using Bookstore.Domain;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Domain.Entities.Genre, Models.Genre>()
             .ReverseMap();
        }
    }
}