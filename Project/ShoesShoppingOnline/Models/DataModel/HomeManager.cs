using X.PagedList;

namespace ShoesShoppingOnline.Models.DataModel
{
    public class HomeManager
    {
        public List<CategoryModel> categories { get; set; }

        public IPagedList<ProductModel> products { get; set; }

        public List<BrandModel> brands { get; set; }
    }
}
