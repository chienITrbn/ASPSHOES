using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class AccountHs160974
    {
        public AccountHs160974()
        {
            CustomersHs160974s = new HashSet<CustomersHs160974>();
        }

        public int AccountId { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public int Role { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<CustomersHs160974> CustomersHs160974s { get; set; }
    }
}
