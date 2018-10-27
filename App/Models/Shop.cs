using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.App.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; private set; }

        public Shop()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public bool RemoveProductByName(string name)
        {
            var product = Products.FirstOrDefault(x => x.Name == name);
            if (product == null)
            {
                return false;
            }
            Products.Remove(product);
            return true;
        }

        public void ShowProducts()
        {
            foreach (var product in Products)
            {
                ShowProductOnConsole(product);
            }
        }

        private void ShowProductOnConsole(Product product)
        {
            Console.WriteLine($"Name: {product.Name}, Description: {product.Description}, StandardPrice: {product.StandardPrice}, Producent: {product.Producent}");
        }
    }
}