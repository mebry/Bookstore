using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Dtos
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int BookId { get; set; }
        
        public int Quantity { get; set; }
    }
}
