using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Interface
{
    public interface ICustomerRepository
    {
        public CustomerModel GetCustomer(int id);
    }
}
