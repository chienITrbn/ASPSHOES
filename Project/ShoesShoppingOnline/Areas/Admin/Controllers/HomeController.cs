using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Models.Validation;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [Route("Dashboard")]

        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("ManagerProduct")]
        public IActionResult ManagerProduct()
        {
            var getAllProduct = _productRepository.getAllProduct();
            return View(getAllProduct);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create() {
            return View(new ProductModel());
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel model)
        {
            var validator = new ProductValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {

            }
            return View(model);
        }
    }
}
