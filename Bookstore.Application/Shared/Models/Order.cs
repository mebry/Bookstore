using Bookstore.Application.Shared.Identity;

namespace Bookstore.Persistence.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
