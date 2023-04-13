using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class AuthorForCreation
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [Display(Name = "Surname")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        [Display(Name = "Image url")]
        public string ProfilePictureURL { get; set; } = string.Empty;
    }
}
