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
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData["CreateSuccess"] != null)
            {
                ViewBag.CreateSuccess = TempData["CreateSuccess"].ToString();
            }
            var getAllProduct = _productRepository.getAllProduct().OrderByDescending(d => d.CreatedAt);
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
                _productRepository.AddProduct(model);
                TempData["CreateSuccess"] = "Create Successfully!";
                return RedirectToAction("ManagerProduct");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int Pid)
        {
            var productById = _productRepository.getProductById(Pid);
            if (productById == null)
            {
                return NotFound();
            }
            return View(productById);
        }        
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(ProductModel model,int Pid)
        {
            var validator = new ProductValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                _productRepository.UpdateProduct(model,Pid);
                TempData["SuccessMessage"] = "Edit Successfully!";
                return RedirectToAction("ManagerProduct");
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
        [Route("Delete")]
        public IActionResult Delete(int Pid)
        {
            _productRepository.DeleteProduct(Pid);
            TempData["DeleteSuccessMessage"] = "Delete successful!";
            return RedirectToAction("ManagerProduct");
        }
    }
}
