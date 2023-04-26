using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class UserForSignUp
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage =
            "The {0} field must have a minimum of {2} and a maximum of {1} characters", MinimumLength = 5)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
