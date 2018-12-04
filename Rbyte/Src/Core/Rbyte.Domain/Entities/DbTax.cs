using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbTax
    {
        public DbTax()
        {
            Products = new HashSet<DbProduct>();
        }
        public int TaxId { get; set; }
        public decimal Value { get; set; }
        public virtual ICollection<DbProduct> Products { get; private set; }
    }
}