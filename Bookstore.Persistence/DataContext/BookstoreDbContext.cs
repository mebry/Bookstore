using Bookstore.Persistence.Configurations;
using Bookstore.Persistence.Identity;
using Bookstore.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Bookstore.Persistence.DataContext
{
    public class BookstoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres => Set<Genre>();

        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Book> Books => Set<Book>();

        public DbSet<Cart> Carts => Set<Cart>();

        public DbSet<CartDetail> CartDetails => Set<CartDetail>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        public DbSet<AuthorBook> AuthorsBooks => Set<AuthorBook>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorBookConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartDetailConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorBookConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);
    }
}