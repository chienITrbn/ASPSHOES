using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class OrdersHs160974
    {
        public OrdersHs160974()
        {
            OrderDetailsHs160974s = new HashSet<OrderDetailsHs160974>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalMoney { get; set; }
        public int CustomerId { get; set; }

        public virtual CustomersHs160974 Customer { get; set; } = null!;
        public virtual ICollection<OrderDetailsHs160974> OrderDetailsHs160974s { get; set; }
    }
}
