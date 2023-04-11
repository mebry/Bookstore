using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Application.Shared.Models;

namespace Bookstore.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.ImageURL)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("Price", "Price > 0"));

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
