using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class UserCartDetails
    {
        public int Id { get; set; }
        
        public int CartId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public string BookName { get; set; } = string.Empty;

        public double UnitPrice { get; set; }

        public string BookImageURL { get; set; } = string.Empty;
    }
}
