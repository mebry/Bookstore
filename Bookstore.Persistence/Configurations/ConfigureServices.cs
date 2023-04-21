using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Shared.Identity;
using Bookstore.Infrastructure.Persistance.DataContext;
using Bookstore.Infrastructure.Persistance.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Persistence.Repositories;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Infrastructure.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BookstoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(BookstoreDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<BookstoreDbContext>());

            services.AddScoped<IDbContextInitializer, BookstoreDbContextInitializer>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorBookRepository,AuthorBookRepository>()
                .AddScoped<IGenreRepository,GenreRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookstoreDbContext>();

            return services;
        }
    }
}