namespace ShoesShoppingOnline.Models.DataModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Image { get; set; } = null!;
    }
}
