namespace Rbyte.Domain.Entities
{
    public class DbCategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public virtual DbCategory Category { get; set; }
        public virtual DbProduct Product { get; set; }
    }
}