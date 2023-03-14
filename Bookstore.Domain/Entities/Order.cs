﻿namespace Bookstore.Domain.Entities
{
    public class Order
    { 
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}