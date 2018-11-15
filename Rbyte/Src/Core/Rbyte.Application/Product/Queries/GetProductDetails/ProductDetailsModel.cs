namespace Rbyte.Application.Product.Queries.GetProductDetails
{
    public class ProductDetailsModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public long Barcode { get; set; }
        public int? ProducerId { get; set; }
        public string ProducerName { get; set; }
    }
}
