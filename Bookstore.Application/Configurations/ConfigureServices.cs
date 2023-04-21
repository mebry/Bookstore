using Bookstore.Application.Common.Behaviours;
using Bookstore.Application.Common.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookstore.Application.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>()
                .AddScoped<IAuthorBookService, AuthorBookService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IGenreService, GenreService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
