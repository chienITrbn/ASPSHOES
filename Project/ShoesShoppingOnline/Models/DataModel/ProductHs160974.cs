using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class ProductHs160974
    {
        public ProductHs160974()
        {
            SizeHs160974s = new HashSet<SizeHs160974>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Image { get; set; } = null!;

        public virtual BrandHs160974 Brand { get; set; } = null!;
        public virtual CategoryHs160974 Category { get; set; } = null!;
        public virtual ICollection<SizeHs160974> SizeHs160974s { get; set; }
    }
}
