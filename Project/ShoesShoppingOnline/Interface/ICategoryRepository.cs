using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> getAllCat();

        CategoryModel getCategory(int id);
    }
}
