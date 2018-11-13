namespace Rbyte.Application.Product.Create
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Barcode { get; set; }
        public int? ProducerId { get; set; }
    }
}
