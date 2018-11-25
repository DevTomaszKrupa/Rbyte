using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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
        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
