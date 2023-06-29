using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class OrderDetailsHs160974
    {
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual OrdersHs160974 Order { get; set; } = null!;
        public virtual SizeHs160974 Size { get; set; } = null!;
    }
}
