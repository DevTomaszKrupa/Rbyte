using Rbyte.Application.Product.Read;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using Rbyte.Persistance.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Product.Create
{
    public interface IProductService
    {
        void Create(CreateProductModel model);
        ReadProductModel Read(int productId);
        IEnumerable<ReadProductModel> Read();
        void Delete(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly RbyteContext _context;

        public ProductService()
        {
            _context = new DesignTimeDbContextFactory().CreateDbContext(null);
        }

        public void Create(CreateProductModel model)
        {
            _context.Products.Add(new DbProduct
            {
                Barcode = model.Barcode,
                Description = model.Description,
                Name = model.Name,
                ProducerId = model.ProducerId,
                StandardPrice = model.Price
            });
            _context.SaveChanges();
        }

        public ReadProductModel Read(int productId)
        {
            var product = _context.Products.Where(x => x.ProductId == productId)
                                           .Select(x => new ReadProductModel
                                           {
                                               ProductId = x.ProductId,
                                               Barcode = x.Barcode,
                                               Description = x.Description,
                                               Name = x.Name,
                                               Price = $"{x.StandardPrice} PLN"
                                           }).FirstOrDefault();
            return product;
        }

        public IEnumerable<ReadProductModel> Read()
        {
            var products = _context.Products.Select(x => new ReadProductModel
            {
                ProductId = x.ProductId,
                Barcode = x.Barcode,
                Description = x.Description,
                Name = x.Name,
                Price = $"{x.StandardPrice} PLN"
            }).ToList();

            return products;
        }

        public void Delete(int productId)
        {
            var dbProduct = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            _context.Products.Remove(dbProduct);
            _context.SaveChanges();
        }
    }
}
