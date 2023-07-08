using ShoesShoppingOnline.Models.DataModel;
using System.Drawing;

namespace ShoesShoppingOnline.Models.Cart
{
    public class CartModel
    {
        public List<Item> _items { get; set; } = new List<Item>();

        public void AddItem(ProductModel product , int quantity , int sizeId)
        {
            Item? existingItem = _items.FirstOrDefault(i => i.Product.ProductId == product.ProductId && i.Size.SizeId == sizeId);
            if (existingItem == null)
            {
                SizeHs160974 size = GetSize(product.ProductId, sizeId);
                if(size != null)
                {
                    existingItem = new Item
                    {
                        Product = product,
                        quantity = quantity,
                        Size = size
                    };
                    _items.Add(existingItem);
                }
            }
            else
            {
                existingItem.quantity += quantity;
            }
        }

        private SizeHs160974 GetSize(int productId, int sizeId)
        {
            PRN211_HS160974Context context = new PRN211_HS160974Context();
            return context.SizeHs160974s.FirstOrDefault(s => s.Pid == productId && s.SizeId == sizeId);
        }

        public decimal ComputeTotalValue() => (decimal)_items.Sum(i => i.quantity * (i.Product.Price));

        public void Clear() => _items.Clear();
    }
}
