using System;
using System.Collections.Generic;
using Rbyte.App.Models;

namespace Rbyte.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop
            {
                ShopId = 1,
                Name = "Bakeroph",
                Address = "Warsaw, Cicha 12/5"
            };

            var prod1 = new Product("Bread", "Gluten free", (decimal)2.99, "Bredex");
            var prod2 = new Product("Milk", "White as snow", (decimal)3.49, "ForthE");

            shop.AddProduct(prod1);
            shop.AddProduct(prod2);

            shop.ShowProducts();
            Console.ReadLine();
        }
    }
}
