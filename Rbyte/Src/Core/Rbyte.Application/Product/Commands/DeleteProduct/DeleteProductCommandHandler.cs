using Rbyte.Persistance;

namespace Rbyte.Application.Product.Commands.DeleteProduct
{
    public interface IDeleteProductCommandHandler
    {
        void Handle(DeleteProductCommand request);
    }

    public sealed class DeleteProductCommandHandler : IDeleteProductCommandHandler
    {
        private readonly RbyteContext _context;

        public DeleteProductCommandHandler(RbyteContext context)
        {
            _context = context;
        }

        public void Handle(DeleteProductCommand request)
        {
            var entity = _context.Products.Find(request.ProductId);

            _context.Products.Remove(entity);
            _context.SaveChanges();
        }
    }
}
