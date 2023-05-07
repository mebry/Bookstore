using Bookstore.Application.Shared.Identity;

namespace Bookstore.Application.Shared.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }

        public List<CartDetail> CartDetails { get; set; } = new();
    }
}
