using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Interface
{
    public class BrandRepository : IBrandRepository
    {
        private PRN211_HS160974Context _context;

        public BrandRepository(PRN211_HS160974Context context) { 
            _context = context;
        }
        public List<BrandModel> getAllBrand()
        {
            var getAllBrand = _context.BrandHs160974s.Select(b => new BrandModel
            {
                Id = b.Id,
                Name = b.Name,
            });
            return getAllBrand.ToList();
        }

        public BrandModel getBrand(int id)
        {
            var getBrandById = _context.BrandHs160974s.SingleOrDefault(c => c.Id == id);
            if (getBrandById != null)
            {
                return new BrandModel { Id = getBrandById.Id, Name = getBrandById.Name };
            }
            return null;
        }
    }
}
