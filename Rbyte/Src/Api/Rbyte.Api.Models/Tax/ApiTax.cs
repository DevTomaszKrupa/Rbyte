using Rbyte.Api.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rbyte.Api.Models.Tax
{
    public class ApiTax
    {
        public int TaxId { get; set; }
        public decimal Value { get; set; }
    }
}
