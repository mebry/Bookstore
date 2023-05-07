namespace Bookstore.Domain.DisplayModels
{
    public class OrderInformation
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public double TotalPrice { get; set; } 
    }
}
