using Bookstore.Application.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bookstore.Application.Common.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Genre> Genres { get; }

        DbSet<Author> Authors { get; }

        DbSet<Book> Books { get; }

        DbSet<Cart> Carts { get; }

        DbSet<CartDetail> CartDetails { get; }

        DbSet<Order> Orders { get; }

        DbSet<OrderDetail> OrderDetails { get; }

        DbSet<AuthorBook> AuthorsBooks { get; }

        Task SaveChangesAsync();
    }
}
