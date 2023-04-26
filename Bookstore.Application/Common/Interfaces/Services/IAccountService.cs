using Bookstore.Application.Common.Models;
using Bookstore.Application.Shared.Identity;
using Bookstore.Domain.Dtos;

namespace Bookstore.Application.Common.Interfaces.Services
{
    public interface IAccountService 
    {
        Task<Response<bool>> RegisterAsync(ApplicationUser user, string password);

        Task<Response<bool>> LoginAsync(string email, string password);

        Task<Response<bool>> LogoutAsync();
    }
}
