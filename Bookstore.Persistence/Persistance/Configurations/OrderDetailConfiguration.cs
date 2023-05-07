using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Application.Shared.Models;

namespace Bookstore.Infrastructure.Persistance.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(p => p.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Book)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(p => p.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
