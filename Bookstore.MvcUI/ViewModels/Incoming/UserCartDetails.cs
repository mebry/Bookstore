using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class UserCartDetails
    {
        public int Id { get; set; }
        [Required]
        public int CartId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string ImageURL { get; set; } = string.Empty;
    }
}
