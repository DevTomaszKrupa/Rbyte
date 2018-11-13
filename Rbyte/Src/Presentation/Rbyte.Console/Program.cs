using Rbyte.Application.Product.Create;
using System;

namespace Rbyte.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            while (true)
            {
                ShowMenu();
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowProductList();
                        Console.ReadLine();
                        break;
                    case "2":
                        AddProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                }
                Console.Clear();
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("1. Show product list");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Delete product");
        }

        private static void ShowProductList()
        {
            var productService = new ProductService();
            var products = productService.Read();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId}. {product.Name} - {product.Price}");
            }
        }

        private static void AddProduct()
        {
            var productService = new ProductService();

            Console.WriteLine("Wprowadz nowy produkt");

            Console.Write("Podaj nazwę: ");
            var name = Console.ReadLine();

            Console.Write("Podaj opis: ");
            var description = Console.ReadLine();

            Console.Write("Podaj cenę: ");
            var priceStr = Console.ReadLine();
            var price = decimal.Parse(priceStr);

            var newProduct = new CreateProductModel
            {
                Description = description,
                Name = name,
                Price = price
            };

            productService.Create(newProduct);
        }

        private static void DeleteProduct()
        {
            ShowProductList();
            var productService = new ProductService();

            Console.WriteLine("Wybierz produkt do usunięcia: ");
            var choiceStr = Console.ReadLine();
            var choice = int.Parse(choiceStr);
            productService.Delete(choice);
        }
    }
}
