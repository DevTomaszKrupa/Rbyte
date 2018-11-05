using System.Collections.Generic;

namespace Rbyte.Models
{
    public class DbProduct
    {
        public DbProduct()
        {
            ProductShops = new HashSet<DbShopProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DbShopProduct> ProductShops { get; set; }
    }
}
