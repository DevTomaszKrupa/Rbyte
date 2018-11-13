using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbProducer
    {
        public DbProducer()
        {
            Products = new HashSet<DbProduct>();
        }

        public int ProducerId { get; set; }
        public string Name { get; set; }
        public ICollection<DbProduct> Products { get; private set; }
    }
}