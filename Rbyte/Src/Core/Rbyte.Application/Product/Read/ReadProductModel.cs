﻿namespace Rbyte.Application.Product.Read
{
    public class ReadProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public long Barcode { get; set; }
        public int Count { get; set; }
        public decimal TaxValue { get; set; }
    }
}
