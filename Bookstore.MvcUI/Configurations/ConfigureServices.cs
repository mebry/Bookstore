using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.MvcUI.UserService;

namespace Bookstore.MvcUI.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddMvcUIServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}