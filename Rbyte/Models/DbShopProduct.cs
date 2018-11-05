namespace Rbyte.Models
{
    public class DbShopProduct
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }

        public virtual DbShop Shop { get; set; }
        public virtual DbProduct Product { get; set; }
    }
}
