using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface IProductRepository
    {
        List<ProductModel> getAllProduct();

        List<ProductModel> getProductsByCategory(int cid);
        List<ProductModel> getProductsByBrand(int bid);

        ProductModel getProductById(int id);

        ProductModel AddProduct(ProductModel product);

        void DeleteProduct(int id);

        void UpdateProduct(ProductModel product,int Pid);
    }
}
