using Bookstore.Application.Common.Models;

namespace Bookstore.Application.Common.Interfaces.Repositories
{
    public interface IIdentityRepository
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<string> CreateUserAsync(string userName, string password);

        Task<bool> DeleteUserAsync(string userId);
    }
}
