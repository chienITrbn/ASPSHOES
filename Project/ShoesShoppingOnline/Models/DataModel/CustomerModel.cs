namespace ShoesShoppingOnline.Models.DataModel
{
	public class CustomerModel
	{
		public int AccountId { get; set; }
		public string FullName { get; set; } = null!;
		public string Address { get; set; } = null!;
		public int CustomerId { get; set; }
		public string PhoneNumber { get; set; }

        //public CustomerModel(int accountId, string fullName, string address, int customerId, string phoneNumber)
        //{
        //    AccountId = accountId;
        //    FullName = fullName;
        //    Address = address;
        //    CustomerId = customerId;
        //    PhoneNumber = phoneNumber;
        //}        
        public CustomerModel(string fullName, string address, string phoneNumber)
        {
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
