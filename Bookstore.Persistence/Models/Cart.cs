using Bookstore.Persistence.Identity;

namespace Bookstore.Persistence.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? ApplicationUser { get; set; }
        
        public List<CartDetail> CartDetails { get; set; } = new();
    }
}
