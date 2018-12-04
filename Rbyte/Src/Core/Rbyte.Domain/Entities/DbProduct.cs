using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbProduct
    {
        public DbProduct()
        {
            ProductDiscounts = new HashSet<DbProductDiscount>();
            ProductCategories = new HashSet<DbCategoryProduct>();
            ProductStores = new HashSet<DbStoreProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StandardPrice { get; set; }
        public long Barcode { get; set; }
        public int? ProducerId { get; set; }
        public virtual DbProducer Producer { get; set; }
        public int? TaxId { get; set; }
        public virtual DbTax Tax { get; set; }
        public virtual ICollection<DbProductDiscount> ProductDiscounts { get; set; }
        public virtual ICollection<DbCategoryProduct> ProductCategories { get; set; }
        public virtual ICollection<DbStoreProduct> ProductStores { get; set; }
    }
}