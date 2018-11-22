namespace Rbyte.Application.Product
{
    public class UpdateProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Barcode { get; set; }
    }
}