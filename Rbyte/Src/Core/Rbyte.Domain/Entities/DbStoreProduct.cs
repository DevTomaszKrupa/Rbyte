namespace Rbyte.Domain.Entities
{
    public class DbStoreProduct
    {
        public int StoreProductId { get; set; }
        public int Count { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public virtual DbStore Store { get; set; }
        public virtual DbProduct Product { get; set; }
    }
}