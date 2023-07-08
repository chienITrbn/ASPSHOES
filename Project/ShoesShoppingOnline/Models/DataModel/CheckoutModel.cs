using ShoesShoppingOnline.Models.Cart;

namespace ShoesShoppingOnline.Models.DataModel
{
    public class CheckoutModel
    {
        public CartModel Cart { get; set; } = new CartModel();

        public OrderModel OrderModel { get; set; } = new OrderModel();

        public OrderDetailModel OrderDetail { get; set; } = new OrderDetailModel();

        public List<OrderModel> OrderList { get; set; } = new List<OrderModel> { new OrderModel() };
    }
}
