using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PRN211_HS160974Context _context;

        public CustomerRepository(PRN211_HS160974Context context)
        {
            _context = context;
        }
        public CustomerModel GetCustomer(int id)
        {
            var getCustomerById = _context.CustomersHs160974s.SingleOrDefault(c => c.AccountId == id);
            if (getCustomerById != null) {
                return new CustomerModel
                {
                    CustomerId = getCustomerById.CustomerId,
                    AccountId = getCustomerById.AccountId,
                    Address = getCustomerById.Address,
                    FullName = getCustomerById.FullName,
                    PhoneNumber = getCustomerById.PhoneNumber
                };
            }
            throw new Exception();
        }
    }
}
