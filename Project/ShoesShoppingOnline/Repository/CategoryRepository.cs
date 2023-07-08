using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;

namespace ShoesShoppingOnline.Interface
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PRN211_HS160974Context _context;
        public CategoryRepository(PRN211_HS160974Context context) {
            _context = context;
        }
        public List<CategoryModel> getAllCat()
        {
            var getAllCat = _context.CategoryHs160974s.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Name,
            });
            return getAllCat.ToList();
        }

        public CategoryModel getCategory(int id)
        {
            var getCatById = _context.CategoryHs160974s.SingleOrDefault(c => c.Id == id);
            if(getCatById != null)
            {
                return new CategoryModel { Id = getCatById.Id, Name = getCatById.Name };
            }
            return null;
        }
    }
}
