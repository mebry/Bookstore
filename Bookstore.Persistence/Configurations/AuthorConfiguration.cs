using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Persistence.Models;

namespace Bookstore.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
