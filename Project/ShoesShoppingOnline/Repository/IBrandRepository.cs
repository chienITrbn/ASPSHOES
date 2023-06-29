using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface IBrandRepository
    {
        List<BrandModel> getAllBrand();

        BrandModel getBrand(int id);
    }
}
