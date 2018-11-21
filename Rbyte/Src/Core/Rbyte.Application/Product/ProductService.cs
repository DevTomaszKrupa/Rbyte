using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Product.Create
{
    public interface IProductService
    {
        ReadProductModel Read(int productId);
        IEnumerable<ReadProductModel> Read();
        void Create(CreateProductModel model);
        UpdateProductModel GetForEdition(int productId);
        void Update(UpdateProductModel model);
        void Delete(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly RbyteContext _context;

        public ProductService(RbyteContext context)
        {
            _context = context;
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
                                           }).First();
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
        public UpdateProductModel GetForEdition(int productId)
        {
            var product = _context.Products
                                    .Where(x => x.ProductId == productId)
                                    .Select(x => new UpdateProductModel
                                    {
                                        ProductId = x.ProductId,
                                        Barcode = x.Barcode,
                                        Description = x.Description,
                                        Name = x.Name,
                                        Price = x.StandardPrice
                                    }).First();
            return product;
        }
        public void Update(UpdateProductModel model)
        {
            var dbProduct = _context.Products.First(x => x.ProductId == model.ProductId);

            dbProduct.Barcode = model.Barcode;
            dbProduct.Description = model.Description;
            dbProduct.Name = model.Name;
            dbProduct.StandardPrice = model.Price;

            _context.SaveChanges();
        }
        public void Delete(int productId)
        {
            var dbProduct = _context.Products.Where(x => x.ProductId == productId).First();
            _context.Products.Remove(dbProduct);
            _context.SaveChanges();
        }
    }
}
