﻿namespace Bookstore.Persistence.Models
{
    public class AuthorBook
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public Book? Book { get; set; }

        public Author? Author { get; set; }
    }
}