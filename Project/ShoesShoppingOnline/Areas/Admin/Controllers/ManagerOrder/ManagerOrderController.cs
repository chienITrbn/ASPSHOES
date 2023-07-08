using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Areas.Admin.Controllers.ManagerOrder
{
    [Area("admin")]
    [Route("admin/Orders")]
    public class ManagerOrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public ManagerOrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [Route("ManagerOrder")]
        public IActionResult ManagerOrder()
        {
            var getAllListOrder = _orderRepository.GetAllOrders();
            return View(getAllListOrder);
        }
    }
}
