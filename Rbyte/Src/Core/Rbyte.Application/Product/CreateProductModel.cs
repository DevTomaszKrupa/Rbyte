using System.ComponentModel.DataAnnotations;

namespace Rbyte.Application.Product
{
    public class CreateProductModel
    {
        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name="Description")]
        public string Description { get; set; }
        [Display(Name="Price")]
        public decimal Price { get; set; }
        [Display(Name="Barcode")]
        public long Barcode { get; set; }
        public int? ProducerId { get; set; }
    }
}
