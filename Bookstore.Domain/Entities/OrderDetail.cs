﻿using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int BookId { get; set; }
        
        public int Quantity { get; set; }
        
        public double UnitPrice { get; set; }
    }
}