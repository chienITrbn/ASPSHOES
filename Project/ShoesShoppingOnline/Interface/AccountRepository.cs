using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using System.Security.Principal;

namespace ShoesShoppingOnline.Interface
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PRN211_HS160974Context _context;

        public AccountRepository(PRN211_HS160974Context context) { 
            _context = context;
        }

		public AccountModel AddAccount(AccountModel account, CustomerModel customer)
		{
			var _account = new AccountHs160974
			{
				AccountId = account.AccountId,
				Email = account.Email,
				Password = account.Password,
				Role = account.Role,
				Active = account.Active,
                Address = account.Address,
                Name = account.Name,
                Phonenumber = account.Phonenumber,
			};
		    _context.AccountHs160974s.Add(_account);
            _context.SaveChanges();
            var _customer = new CustomersHs160974
            {
                FullName = _account.Name,
                AccountId = _account.AccountId,
                Address = _account.Address,
                PhoneNumber = _account.Phonenumber
            };
            _context.CustomersHs160974s.Add(_customer);
			_context.SaveChanges();
            return new AccountModel
            {
                AccountId = account.AccountId,
                Email = account.Email,
                Password = account.Password,
                Role = account.Role,
                Active = account.Active,
                Address = account.Address,
                Name = account.Name,
                Phonenumber = account.Phonenumber
            };
		}

		public AccountModel isExitsAccount(AccountModel accountModel)
        {
            var isExitsAcc = _context.AccountHs160974s.FirstOrDefault(a => a.Email == accountModel.Email && a.Password == accountModel.Password);
            if (isExitsAcc != null)
            {
                return new AccountModel
                {
                    AccountId = isExitsAcc.AccountId,
                    Email = isExitsAcc.Email,
                    Password = isExitsAcc.Password,
                    Phonenumber = isExitsAcc.Phonenumber,
                    Active = isExitsAcc.Active,
                    Address = isExitsAcc.Address,
                    Name = isExitsAcc.Name,
                    Role = isExitsAcc.Role
                };
            }
            else
            {
                return null;
            }
        }


        public bool isExitsEmail(string email)
        {
            var isExitsEm = _context.AccountHs160974s.FirstOrDefault (a => a.Email == email);
            if (isExitsEm != null)
            {
                return true;
            } return false;
        }
    }
}
