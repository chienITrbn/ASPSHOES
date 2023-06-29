using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Controllers.HomePage
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailsController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult ProductDetails(int Pid)
        {
            var getProductById = _productRepository.getProductById(Pid);
            if(getProductById != null)
            {
                return View(getProductById);
            }
            return RedirectToAction("404");
        }
    }
}
