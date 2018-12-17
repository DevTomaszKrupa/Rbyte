using Rbyte.Api.Models.Product;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Product.Create
{
    public interface IProductService
    {
        void Create(ApiProduct model);
        ApiProduct Get(int productId);
        List<ApiProduct> Get();
        void Update(ApiProduct model);
        void Delete(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly RbyteContext _context;

        public ProductService(RbyteContext context)
        {
            _context = context;
        }


        public void Create(ApiProduct model)
        {
            var dbProduct = new DbProduct
            {
                Barcode = model.Barcode,
                Description = model.Description,
                Name = model.Name,
                FullPrice = model.FullPrice,
                PriceWithoutMargin = model.PriceWithoutMargin
            };
            _context.Products.Add(dbProduct);
            //if (model.CategoryId.HasValue)
            //{
            //    _context.CategoryProducts.Add(new DbCategoryProduct
            //    {
            //        CategoryId = model.CategoryId.Value,
            //        ProductId = dbProduct.ProductId
            //    });
            //}
            _context.SaveChanges();
        }

        public ApiProduct Get(int productId)
        {
            var product = _context.Products.Where(x => x.ProductId == productId)
                                           .Select(x => new ApiProduct
                                           {
                                               ProductId = x.ProductId,
                                               Barcode = x.Barcode,
                                               Description = x.Description,
                                               Name = x.Name,
                                               FullPrice = x.FullPrice,
                                               PriceWithoutMargin = x.PriceWithoutMargin
                                           }).First();
            return product;
        }

        public List<ApiProduct> Get()
        {
            var products = _context.Products.Select(x => new ApiProduct
            {
                ProductId = x.ProductId,
                Barcode = x.Barcode,
                Description = x.Description,
                Name = x.Name,
                FullPrice = x.FullPrice,
                PriceWithoutMargin = x.PriceWithoutMargin
            }).ToList();

            return products;
        }

        public void Update(ApiProduct model)
        {
            var dbProduct = _context.Products.First(x => x.ProductId == model.ProductId);

            dbProduct.Barcode = model.Barcode;
            dbProduct.Description = model.Description;
            dbProduct.Name = model.Name;
            dbProduct.FullPrice = model.FullPrice;
            dbProduct.PriceWithoutMargin = model.PriceWithoutMargin;

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
