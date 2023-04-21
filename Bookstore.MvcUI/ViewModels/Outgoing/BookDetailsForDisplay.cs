using Bookstore.MvcUI.Models.Outgoing;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.MvcUI.ViewModels.Outgoing
{
    public class BookDetailsForDisplay
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Image url")]
        public string ImageURL { get; set; } = string.Empty;

        [Display(Name = "CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Genre")]
        public string GenreName{ get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Authors")]
        public IEnumerable<AuthorForDisplay> Authors { get; set; }
    }
}
