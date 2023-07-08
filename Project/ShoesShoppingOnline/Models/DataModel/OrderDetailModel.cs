namespace ShoesShoppingOnline.Models.DataModel
{
    public class OrderDetailModel
    {
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
