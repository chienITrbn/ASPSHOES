using Microsoft.EntityFrameworkCore;
using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PRN211_HS160974Context _context;

        public OrderRepository(PRN211_HS160974Context context)
        {
            _context = context;
        }
        public void AddNewOrder(OrderModel orderModel, CustomerModel customerModel)
        {
            var getNewOrder = new OrdersHs160974
            {
                CustomerId = customerModel.CustomerId,
                OrderDate = orderModel.OrderDate,
                TotalMoney = orderModel.TotalMoney,
            };
            _context.OrdersHs160974s.Add(getNewOrder);
            _context.SaveChanges();
            orderModel.OrderId = getNewOrder.OrderId;
        }

        public void AddOrderDetail(OrderDetailModel orderDetailModel)
        {
            var getNewOrderDetail = new OrderDetailsHs160974
            {
                OrderId = orderDetailModel.OrderId,
                Price = orderDetailModel.Price,
                Quantity = orderDetailModel.Quantity,
                SizeId = orderDetailModel.SizeId
            };
            _context.OrderDetailsHs160974s.Add(getNewOrderDetail);
            _context.SaveChanges();
        }
    }
}
