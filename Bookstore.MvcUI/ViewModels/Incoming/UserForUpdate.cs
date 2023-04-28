using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class UserForUpdate
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; } = string.Empty;
    }
}
