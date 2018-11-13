namespace Rbyte.Domain.Entities
{
    public class DbProductDiscount
    {
        public int ProductId { get; set; }
        public virtual DbProduct Product { get; set; }
        public int DiscountId { get; set; }
        public virtual DbDiscount Discount { get; set; }
    }
}