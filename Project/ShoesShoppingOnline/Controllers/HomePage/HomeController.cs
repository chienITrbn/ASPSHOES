using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using X.PagedList;
namespace ShoesShoppingOnline.Controllers.HomePage
{
	public class HomeController : Controller
	{
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public HomeController(IProductRepository productRepository,ICategoryRepository categoryRepository,IBrandRepository brandRepository) {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
		public IActionResult Index(int ? page)
		{
            int pageSize = 3;
            int pageNumber = (page ?? 1);
			var getAllProduct = _productRepository.getAllProduct().ToPagedList(pageNumber,pageSize);
			var getAllCat = _categoryRepository.getAllCat();
			var getAllBrand = _brandRepository.getAllBrand(); 
			var listManager = new HomeManager
			{
				products = getAllProduct,
				categories = getAllCat,
				brands = getAllBrand,
			};
			return View(listManager);
		}

		public IActionResult GetProductByCategory(int cid)
		{
			var getProductByCategory = _productRepository.getProductsByCategory(cid);
			return PartialView("_ProductByCategory", getProductByCategory);
		}		
		
		public IActionResult GetProductByBrand(int bid)
		{
			var getProductByBrand = _productRepository.getProductsByBrand(bid);
			return PartialView("_ProductByBrand", getProductByBrand);
		}


    }
}
