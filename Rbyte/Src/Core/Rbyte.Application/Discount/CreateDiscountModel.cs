using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rbyte.Application.Discount
{
    public class CreateDiscountModel
    {
        public decimal Value { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public int? ProductId { get; set; }
        public int? DiscountId { get; set; }
    }
}