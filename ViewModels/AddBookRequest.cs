using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class AddBookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public int YearOfPublication { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int AmountInStorage { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
