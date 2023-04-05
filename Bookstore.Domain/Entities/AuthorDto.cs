namespace Bookstore.Domain.Entities
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ProfilePictureURL { get; set; } = string.Empty;
    }
}
