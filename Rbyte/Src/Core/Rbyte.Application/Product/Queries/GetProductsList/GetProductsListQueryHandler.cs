using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Product.Queries.GetProductsList
{
    public interface IGetProductsListQueryHandler
    {
        List<ProductLookupModel> Handle();
    }

    public sealed class GetProductsListQueryHandler : IGetProductsListQueryHandler
    {
        private readonly RbyteContext _context;

        public GetProductsListQueryHandler(RbyteContext context)
        {
            _context = context;
        }

        public List<ProductLookupModel> Handle()
        {
            var products = _context.Products.Select(x => new ProductLookupModel
            {
                Name = x.Name,
                ProductId = x.ProductId
            }).ToList();

            return products;
        }
    }
}
