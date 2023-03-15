using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Persistence.Models;
using System.Reflection.Emit;

namespace Bookstore.Persistence.Configurations
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(p => new
            {
                p.AuthorId,
                p.BookId
            });

            builder.HasOne(p => p.Book)
                .WithMany(p => p.AuthorBooks)
                .HasForeignKey(p => p.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Author)
                .WithMany(p => p.AuthorBooks)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
