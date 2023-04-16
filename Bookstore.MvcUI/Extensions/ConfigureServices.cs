namespace Bookstore.MvcUI.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMvcUIServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);

            return services;
        }
    }
}


