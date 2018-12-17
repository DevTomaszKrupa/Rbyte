namespace Rbyte.Api.Models.Product
{
    public class ApiProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Barcode { get; set; }
        public int Tax { get; set; }
        public decimal PriceWithoutMargin { get; set; }
        public decimal FullPrice { get; set; }
    }
}
