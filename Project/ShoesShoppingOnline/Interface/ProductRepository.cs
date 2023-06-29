using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Interface
{
    public class ProductRepository : IProductRepository
    {
        private readonly PRN211_HS160974Context _context;

        public ProductRepository(PRN211_HS160974Context context)
        {
            _context = context;
        }
        public ProductModel AddProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> getAllProduct()
        {
            var products = _context.ProductHs160974s.Select(x => new ProductModel
            {
                ProductId = x.ProductId,
                Name = x.Name,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                Image = x.Image,
                Price = x.Price
            });
            return products.ToList();
        }

        public ProductModel getProductById(int id)
        {
            var getProductById = _context.ProductHs160974s.SingleOrDefault(x => x.ProductId == id);
            if (getProductById == null)
            {
                throw new InvalidOperationException("Not Found Product");
            }
            return new ProductModel
            {
                CategoryId = getProductById.CategoryId,
                BrandId = getProductById.BrandId,
                Name = getProductById.Name,
                Description = getProductById.Description,
                Price = getProductById.Price,
                ProductId = getProductById.ProductId,
                Image = getProductById.Image,
            };
        }


        public void UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
