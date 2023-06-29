namespace ShoesShoppingOnline.Models.DataModel
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public int Role { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;

        public AccountModel()
        {
            
        }
        public AccountModel(string password, string name, string phonenumber, int role, bool active, string email, string address)
        {
            Password = password;
            Name = name;
            Phonenumber = phonenumber;
            Role = role;
            Active = active;
            Email = email;
            Address = address;
        }
    }
}
