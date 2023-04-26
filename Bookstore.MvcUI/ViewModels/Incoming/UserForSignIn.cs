using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class UserForSignIn
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = 
            "The {0} field must have a minimum of {2} and a maximum of {1} characters", MinimumLength = 5)]
        public string Password { get; set; } = string.Empty;
    }
}
