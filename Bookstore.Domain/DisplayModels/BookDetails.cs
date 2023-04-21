using Bookstore.Domain.Dtos;

namespace Bookstore.Domain.DisplayModels
{
    public class BookDetails
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string GenreName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<AuthorDto> Authors { get; set; } = new();
    }
}
