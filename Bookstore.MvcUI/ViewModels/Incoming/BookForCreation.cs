using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Incoming
{
    public class BookForCreation
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Image url")]
        [Required(ErrorMessage = "The book URL is required")]
        public string ImageURL { get; set; } = string.Empty;

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Book author(s) is required")]
        public List<int> AuthorsId { get; set; } = new();

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "The genre is required")]
        public int GenreId { get; set; }

        [Display(Name = "Created")]
        [Required(ErrorMessage = "The creation time is required")]
        public DateTime CreatedAt { get; set; }
    }
}
