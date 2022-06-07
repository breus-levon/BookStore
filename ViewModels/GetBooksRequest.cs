using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class GetBooksRequest
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public int YearOfPublication { get; set; }
        [Required]
        public int AmountInStorage { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
