using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class CustomersHs160974
    {
        public CustomersHs160974()
        {
            OrdersHs160974s = new HashSet<OrdersHs160974>();
        }

        public int AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual AccountHs160974 Account { get; set; } = null!;
        public virtual ICollection<OrdersHs160974> OrdersHs160974s { get; set; }
    }
}
