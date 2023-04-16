namespace Bookstore.Application.Common.Interfaces.Context
{
    public interface IDbContextInitializer
    {
        Task InitialiseAsync();
    }
}