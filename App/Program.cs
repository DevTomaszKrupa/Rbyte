using System;
using System.Collections.Generic;
using App.Logic;
using Rbyte.App.Models;

namespace Rbyte.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var productFactory = new ProductFactory();
            var productService = new ProductService(productFactory.CreateProducts(100));

            var cheapestProducts = productService.GetTheCheapestProducts(5);
            Console.WriteLine("The cheapest products:");
            cheapestProducts.ForEach(x => DisplayProduct(x));

            Console.WriteLine();
            Console.WriteLine();

            var mostExpensiveProducts = productService.GetTheMostExcensiveProducts(5);
            Console.WriteLine("The most expensive products:");
            mostExpensiveProducts.ForEach(x => DisplayProduct(x));

            Console.ReadLine();
        }

        static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.Producent}, {product.Name}, {product.Description}, {product.StandardPrice}");
        }
    }
}
