using Group4_GlassesShop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly PRN211_HS160974Context _context;
        private IProductRepository _productRepository;

        public AddToCart(PRN211_HS160974Context context,IProductRepository productRepository) {
            _context = context;
            _productRepository = productRepository;
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
    }
}
