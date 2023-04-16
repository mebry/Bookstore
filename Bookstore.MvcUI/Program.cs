using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Configurations;
using Bookstore.Infrastructure.Configurations;
using Bookstore.MvcUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddMvcUIServices();

var app = builder.Build();

//creates a new service scope where you can get instances of services registered in the dependency container
using (var scope = app.Services.CreateScope())
{
    var dbContextInitializer = scope.ServiceProvider.GetRequiredService<IDbContextInitializer>();

    await dbContextInitializer.InitialiseAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change
    // this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Author}/{action=Index}/{id?}");

app.Run();
