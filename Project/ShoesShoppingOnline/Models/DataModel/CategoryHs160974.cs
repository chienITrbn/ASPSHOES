using System;
using System.Collections.Generic;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class CategoryHs160974
    {
        public CategoryHs160974()
        {
            ProductHs160974s = new HashSet<ProductHs160974>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductHs160974> ProductHs160974s { get; set; }
    }
}
