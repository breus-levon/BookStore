using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class EditBookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public int YearOfPublication { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
