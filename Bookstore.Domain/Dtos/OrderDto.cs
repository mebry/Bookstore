namespace Bookstore.Domain.Dtos
{
    public class OrderDto
    { 
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
