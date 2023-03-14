﻿using Bookstore.Domain.Enums;

namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int GenreId { get; set; }
    }
}
