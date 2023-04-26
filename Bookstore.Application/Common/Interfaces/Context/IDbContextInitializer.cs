using Bookstore.Application.Shared.Identity;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Application.Common.Interfaces.Context
{
    public interface IDbContextInitializer
    {
        Task InitialiseAsync();
        Task InitialiseUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager);
    }
}