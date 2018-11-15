using Rbyte.Domain.Entities;
using Rbyte.Persistance;

namespace Rbyte.Application.Product.Commands.CreateProduct
{
    public interface ICreateProductCommandHandler
    {
        void Handle(CreateProductCommand request);
    }

    public sealed class CreateProductCommandHandler : ICreateProductCommandHandler
    {
        private readonly RbyteContext _context;

        public CreateProductCommandHandler(RbyteContext context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand request)
        {
            var entity = new DbProduct
            {
                Barcode = request.Barcode,
                Description = request.Description,
                Name = request.Name,
                StandardPrice = request.Price,
                ProducerId = request.ProducerId                
            };

            _context.Products.Add(entity);
            _context.SaveChanges();
        }
    }
}
