namespace Bookstore.Persistence.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ProfilePictureURL { get; set; } = string.Empty;

        public List<AuthorBook> AuthorBooks { get; set; } = new();
    }
}