using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class SizeHs160974
    {
        public SizeHs160974()
        {
            OrderDetailsHs160974s = new HashSet<OrderDetailsHs160974>();
        }

        public int SizeId { get; set; }
        public int Pid { get; set; }
        public double SizeName { get; set; }
        public int Quantity { get; set; }

        public virtual ProductHs160974 PidNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetailsHs160974> OrderDetailsHs160974s { get; set; }
    }
}
