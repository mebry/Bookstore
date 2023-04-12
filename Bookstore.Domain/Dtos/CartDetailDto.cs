using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Dtos
{
    public class CartDetailDto
    {
        public int Id { get; set; }
       
        public int CartId { get; set; }
        
        public int BookId { get; set; }
        
        public int Quantity { get; set; }
        
        public double UnitPrice { get; set; }
    }
}
