using System;

namespace Rbyte.App.Models
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal StandardPrice { get; private set; }
        public string Producent { get; private set; }

        // constructor
        public Product(string name, string description, decimal standardPrice, string producent)
        {
            ProductId = new Random().Next();
            Name = name;
            Description = description;
            StandardPrice = standardPrice;
            Producent = producent;
        }
    }
}