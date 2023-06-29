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

        //public ActionResult GetProductsByCategory(int cid)
        //{
        //    var products = (from p in db.Product_HS160974
        //                    join c in db.Category_HS160974 on p.category_id equals c.id
        //                    where p.category_id == cid
        //                    select new
        //                    {
        //                        Id = p.ProductId,
        //                        Name = p.name,
        //                        CategoryName = p.category_id,
        //                        Price = p.price,
        //                        Image = p.image_product
        //                    }).ToList();

        //    var category = _categoryRepository?.name ?? "unknown";

        //    return Json(new { Products = products, Category = category }, JsonRequestBehavior.AllowGet);
        //}
    }
}
