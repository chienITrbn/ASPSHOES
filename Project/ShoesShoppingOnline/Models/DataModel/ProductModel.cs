using System.ComponentModel.DataAnnotations;

namespace ShoesShoppingOnline.Models.DataModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [MinLength(8, ErrorMessage = "Name must have at least 8 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Description must have at least 20 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        public int BrandId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Image path is required")]
        public string Image { get; set; } = null!;
    }
}
