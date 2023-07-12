using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using System.Security.Cryptography;

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
            var _product = new ProductHs160974
            {
                ProductId = product.ProductId,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                CreatedAt = DateTime.UtcNow,
                Description = product.Description,
                Image = "/image/"+product.Image,
                Name = product.Name,
                Price = product.Price,
            };
            _context.ProductHs160974s.Add(_product);
            _context.SaveChanges();
            return new ProductModel 
            {
                ProductId = _product.ProductId,
                BrandId = _product.BrandId,
                CategoryId = _product.CategoryId,
                CreatedAt = _product.CreatedAt,
                Description = _product.Description,
                Image = _product.Image,
                Name = _product.Name,
                Price = _product.Price,
            };
        }

        public void DeleteProduct(int id)
        {
            var _product = _context.ProductHs160974s.FirstOrDefault(p => p.ProductId == id);
            if (_product != null)
            {
                _context.Remove(_product);
                _context.SaveChanges();
            }
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
                Image = getProductById.Image
            };
        }

        public List<ProductModel> getProductsByBrand(int bid)
        {
            var getProductByBid = _context.ProductHs160974s.Where(p => p.BrandId == bid).Select(p => new ProductModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                Image = p.Image,
                Price = p.Price
            }).ToList();
            if (getProductByBid != null)
            {
                return getProductByBid;
            }
            throw new InvalidOperationException("Not Found");
        }

        public List<ProductModel> getProductsByCategory(int cid)
        {
            var getProductByCid = _context.ProductHs160974s.Where(p => p.CategoryId == cid).Select(p => new ProductModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                Image = p.Image,
                Price = p.Price
            }).ToList();
            if (getProductByCid != null)
            {
                return getProductByCid;
            }
            throw new InvalidOperationException("Not Found");
        }

        public void UpdateProduct(ProductModel product , int id)
        {
            var _product = _context.ProductHs160974s.FirstOrDefault(p => p.ProductId == id);
            if (_product == null)
            {
                throw new Exception();
            }
            else
            {
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.Price = product.Price;
                _product.Image = product.Image;
                _product.CategoryId = product.CategoryId;
                _product.UpdatedAt = DateTime.Now;
                _product.BrandId = product.BrandId;
                _context.ProductHs160974s.Update(_product);
                _context.SaveChanges();
            }
        }
    }
}
