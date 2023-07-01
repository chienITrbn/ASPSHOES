using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Models.Cart
{
    public class Item
    {
        public ProductModel Product { get; set; } = new ProductModel();

        public SizeHs160974 Size { get; set; } = new SizeHs160974();
        public int quantity { get; set; } 
    }
}
