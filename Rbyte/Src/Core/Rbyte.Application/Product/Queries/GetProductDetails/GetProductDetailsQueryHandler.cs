using Rbyte.Persistance;
using System.Linq;

namespace Rbyte.Application.Product.Queries.GetProductDetails
{
    public interface IGetProductDetailsQueryHandler
    {
        ProductDetailsModel Handle(GetProductDetailsQuery request);
    }

    public sealed class GetProductDetailsQueryHandler : IGetProductDetailsQueryHandler
    {
        private readonly RbyteContext _context;

        public GetProductDetailsQueryHandler(RbyteContext context)
        {
            _context = context;
        }

        public ProductDetailsModel Handle(GetProductDetailsQuery request)
        {
            var product = _context.Products
                            .Where(x => x.ProductId == request.ProductId)
                            .Select(x => new ProductDetailsModel
                            {
                                Barcode = x.Barcode,
                                Description = x.Description,
                                Name = x.Name,
                                Price = $"{x.StandardPrice} PLN",
                                ProducerId = x.ProducerId,
                                ProducerName = x.Producer != null ? x.Producer.Name : "Nie znaleziono",
                                ProductId = x.ProductId
                            }).FirstOrDefault();
            return product;
        }
    }
}
