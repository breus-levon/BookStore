using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class EditAuthorRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
