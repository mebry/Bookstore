using Bookstore.Application.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasAlternateKey(p => p.Name);

            builder.Property(p => p.Name).HasMaxLength(100);

            builder.HasMany(p => p.Books)
                .WithOne(p=>p.Genre)
                .HasForeignKey(u => u.GenreId);
        }
    }
}
