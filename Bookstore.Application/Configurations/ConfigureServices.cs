using Bookstore.Application.Common.Behaviours;
using Bookstore.Application.Common.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>().
                AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
