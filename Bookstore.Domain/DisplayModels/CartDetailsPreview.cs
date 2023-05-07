namespace Bookstore.Domain.DisplayModels
{
    public class CartDetailsPreview
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string BookImageURL { get; set; } = string.Empty;

        public string BookName { get; set; } = string.Empty;
    }
}
