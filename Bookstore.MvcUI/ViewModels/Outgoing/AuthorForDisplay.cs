using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.Models.Outgoing
{
    public class AuthorForDisplay
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Surname")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Image url")]
        public string ProfilePictureURL { get; set; } = string.Empty;
    }
}
