using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price ir required")]
        [Range(1, 99999.99)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
