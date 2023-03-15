namespace Bookstore.Persistence.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; } = new();

        public List<OrderDetail> OrderDetails { get; set; } = new();

        public List<CartDetail> CartDetails { get; set; } = new();
    }
}