using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Application.Shared.Models;

namespace Bookstore.Persistence.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasOne(p => p.Cart)
                .WithMany(p => p.CartDetails)
                .HasForeignKey(p => p.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.Book)
                .WithMany(p=>p.CartDetails)
                .HasForeignKey(p=>p.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
