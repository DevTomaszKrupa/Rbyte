using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Rbyte.Application.Product.Create
{
    public class CreateProductModel
    {
        public CreateProductModel()
        {
            CategorySelectList = new List<SelectListItem>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Barcode { get; set; }
        public int? ProducerId { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public int? TaxId { get; set; }
        public IEnumerable<SelectListItem> TaxSelectList { get; set; }
    }
}
