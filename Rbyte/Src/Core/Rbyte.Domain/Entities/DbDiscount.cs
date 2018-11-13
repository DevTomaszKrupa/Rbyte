using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbDiscount
    {
        public DbDiscount()
        {
            DiscountProducts = new HashSet<DbProductDiscount>();
        }
        
        public int DiscountId { get; set; }
        public decimal Value { get; set; }
        public virtual ICollection<DbProductDiscount> DiscountProducts { get; private set; }
    }
}