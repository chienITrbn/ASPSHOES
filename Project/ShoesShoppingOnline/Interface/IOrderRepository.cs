using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface IOrderRepository
    {
        public void AddNewOrder(OrderModel orderModel,CustomerModel customerModel);

        public void AddOrderDetail(OrderDetailModel orderDetailModel);

        public List<OrderModel> GetAllOrders();
    }
}
