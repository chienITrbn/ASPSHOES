using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface IProductRepository
    {
        List<ProductModel> getAllProduct();

        ProductModel getProductById(int id);

        ProductModel AddProduct(ProductModel product);

        void DeleteProduct(int id);

        void UpdateProduct(ProductModel product);
    }
}
