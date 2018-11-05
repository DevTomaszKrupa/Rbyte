using System.Collections.Generic;

namespace Rbyte.Models
{
    public class DbShop
    {
        public DbShop()
        {
            ShopProducts = new HashSet<DbShopProduct>();
        }

        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Shortcut { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DbShopProduct> ShopProducts { get; set; }
    }
}
