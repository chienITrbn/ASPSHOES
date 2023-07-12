using Group4_GlassesShop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Models.Cart;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using System.Drawing;

namespace ShoesShoppingOnline.Controllers.Cart
{
    public class AddToCart : Controller
    {
        public CartModel? cart { get; set; }
        private IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public AddToCart(IProductRepository productRepository,IOrderRepository orderRepository , ICustomerRepository customerRepository) {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Cart(int Pid, int sizeID, int quantity)
        {
            ProductModel? product = _productRepository.getProductById(Pid);
            if (product != null)
            {
                cart = HttpContext.Session.GetJson<CartModel>("cart") ?? new CartModel();
                cart.AddItem(product, quantity, sizeID);
                HttpContext.Session.SetJon("cart", cart);
            }
            return View(cart);
        }

        public IActionResult ChangeQuantity(int Pid, int quantity)
        {
            ProductModel? product = _productRepository.getProductById(Pid);
            if (product != null)
            {
                cart = HttpContext.Session.GetJson<CartModel>("cart");
                cart.ChangeQuantity(product, quantity);
                HttpContext.Session.SetJon("cart", cart);
            }
            return View("Cart", cart);
        }

        public IActionResult Checkout(CartModel checkoutModel) {
            string accountJson = HttpContext.Session.GetString("User");
            var cart = HttpContext.Session.GetJson<CartModel>("cart");
            var account = JsonConvert.DeserializeObject<AccountModel>(accountJson);
            int accountId = account.AccountId;
            var Customer = _customerRepository.GetCustomer(accountId);
            var getOrder = new OrderModel
            {               
                OrderDate = DateTime.Now,
                Customers = Customer,
                TotalMoney = cart.ComputeTotalValue()
            };
            _orderRepository.AddNewOrder(getOrder,Customer);
            Console.WriteLine(getOrder.OrderId);
            foreach (var order in cart._items)
            {
                var orderDetails = new OrderDetailModel
                {
                    OrderId = getOrder.OrderId,
                    SizeId = order.Size.SizeId,
                    Quantity = order.quantity,
                    Price = order.Product.Price*order.quantity
                };
                _orderRepository.AddOrderDetail(orderDetails);
                HttpContext.Session.Remove("cart");
            }
            return RedirectToAction("Index","Home");
        }


    }
}
