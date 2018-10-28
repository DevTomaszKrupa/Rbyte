using System.Collections.Generic;
using System.Linq;
using Rbyte.App.Models;

namespace App.Logic
{
    public class ProductService
    {
        private readonly List<Product> _products;
        public ProductService(List<Product> products)
        {
            _products = products;
        }

        public int Count()
        {
            return _products.Count;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public bool Remove(string name)
        {
            var toRemove = _products.Where(x => x.Name == name).FirstOrDefault();
            if (toRemove == null)
                return false;
            _products.Remove(toRemove);
            return true;
        }

        public List<Product> GetTheCheapestProducts(int count)
        {
            var prods = _products
                        .OrderBy(x => x.StandardPrice)
                        .Take(count)
                        .ToList();
            return prods;
        }
        public List<Product> GetTheMostExcensiveProducts(int count)
        {
            var prods = _products
                        .OrderByDescending(x => x.StandardPrice)
                        .Take(count)
                        .ToList();
            return prods;
        }
    }
}