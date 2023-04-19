namespace Bookstore.Domain.DisplayModels
{
    public class BookPreview
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string GenreName { get; set; } = string.Empty;

        public List<string> Authors { get; set; } = new();
    }
}
