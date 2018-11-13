using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbStore
    {
        public DbStore()
        {
            StoreProducts = new HashSet<DbStoreProduct>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DbStoreProduct> StoreProducts { get; set; }
    }
}