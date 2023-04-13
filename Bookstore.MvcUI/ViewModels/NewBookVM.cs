using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.Models
{
    public class NewBookVM
    {
        public int Id { get; set; }

        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book poster URL")]
        [Required(ErrorMessage = "Book poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Created At")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Select author(s)")]
        [Required(ErrorMessage = "Book author(s) is required")]
        public List<int> AuthorsId { get; set; } = new();


        [Display(Name = "Select genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }
    }
}
