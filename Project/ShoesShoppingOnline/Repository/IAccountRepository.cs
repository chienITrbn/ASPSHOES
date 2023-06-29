using ShoesShoppingOnline.Models.DataModel;

namespace ShoesShoppingOnline.Repository
{
    public interface IAccountRepository
    {
        public AccountModel isExitsAccount(AccountModel accountModel);
        public Boolean isExitsEmail(string email);
		public AccountModel AddAccount(AccountModel account, CustomerModel customer);

	}
}
