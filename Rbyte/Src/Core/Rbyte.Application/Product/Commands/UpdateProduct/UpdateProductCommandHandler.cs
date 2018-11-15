using Rbyte.Domain.Entities;
using Rbyte.Persistance;

namespace Rbyte.Application.Product.Commands.UpdateProduct
{
    public interface IUpdateProductCommandHandler
    {
        void Handle(UpdateProductCommand request);
    }

    public sealed class UpdateProductCommandHandler : IUpdateProductCommandHandler
    {
        private readonly RbyteContext _context;

        public UpdateProductCommandHandler(RbyteContext context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand request)
        {
            var entity = new DbProduct
            {
                ProductId = request.ProductId,
                Barcode = request.Barcode,
                Description = request.Description,
                Name = request.Name,
                StandardPrice = request.Price,
                ProducerId = request.ProducerId
            };

            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
