using System;
using System.Collections.Generic;
using Rbyte.App.Models;

namespace App.Logic
{
    public class ProductFactory
    {
        public List<Product> CreateProducts(int count)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var price = new Random().NextDouble() * 10 * i;
                Product temp = new Product($"Product no. {i + 1}", $"Description for product no. {i + 1}", (decimal)price, "RetuKp");
                list.Add(temp);
            }
            return list;
        }
    }
}
