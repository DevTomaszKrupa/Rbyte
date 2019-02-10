using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Product;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbyte.Application.Product.Create
{
    public interface IProductService
    {
        Task CreateAsync(ProductDto model);
        Task<ProductDto> GetAsync(int productId);
        Task<List<ProductDto>> GetAsync();
        Task UpdateAsync(ProductDto model);
        Task DeleteAsync(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly RbyteContext _context;

        public ProductService(RbyteContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(ProductDto model)
        {
            var dbProduct = new DbProduct
            {
                Barcode = model.Barcode,
                Description = model.Description,
                Name = model.Name,
                FullPrice = model.FullPrice,
                PriceWithoutMargin = model.PriceWithoutMargin
            };
            await _context.Products.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
        }

        public Task<ProductDto> GetAsync(int productId)
        {
            var product = _context.Products.Where(x => x.ProductId == productId)
                                           .Select(x => new ProductDto
                                           {
                                               ProductId = x.ProductId,
                                               Barcode = x.Barcode,
                                               Description = x.Description,
                                               Name = x.Name,
                                               FullPrice = x.FullPrice,
                                               PriceWithoutMargin = x.PriceWithoutMargin
                                           }).FirstAsync();
            return product;
        }

        public Task<List<ProductDto>> GetAsync()
        {
            var products = _context.Products.Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                Barcode = x.Barcode,
                Description = x.Description,
                Name = x.Name,
                FullPrice = x.FullPrice,
                PriceWithoutMargin = x.PriceWithoutMargin
            }).ToListAsync();

            return products;
        }

        public async Task UpdateAsync(ProductDto model)
        {
            var dbProduct = await _context.Products.FirstAsync(x => x.ProductId == model.ProductId);

            dbProduct.Barcode = model.Barcode;
            dbProduct.Description = model.Description;
            dbProduct.Name = model.Name;
            dbProduct.FullPrice = model.FullPrice;
            dbProduct.PriceWithoutMargin = model.PriceWithoutMargin;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var dbProduct = await _context.Products.Where(x => x.ProductId == productId).FirstAsync();
            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();
        }
    }
}
