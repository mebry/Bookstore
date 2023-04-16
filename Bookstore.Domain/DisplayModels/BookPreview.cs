namespace Bookstore.Domain.DisplayModels
{
    public class BookPreview
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int Genre { get; set; }

        public List<string> Authors { get; set; } = new();
    }
}
