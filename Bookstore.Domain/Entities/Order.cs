namespace Bookstore.Domain.Entities
{
    public class Order
    { 
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public double Price { get; set; }
    }
}
