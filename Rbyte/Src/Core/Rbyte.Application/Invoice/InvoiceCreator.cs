using Rbyte.Domain.ApiModels.Invoice;
using Rbyte.Persistance;

namespace Rbyte.Application.Invoice
{
    public interface IInvoiceCreator
    {
        void Create(CreateInvoiceRequest createInvoiceRequest);
    }

    public class InvoiceCreator : IInvoiceCreator
    {
        private readonly RbyteContext _context;

        public InvoiceCreator(RbyteContext context)
        {
            _context = context;
        }

        public void Create(CreateInvoiceRequest createInvoiceRequest)
        {
            throw new System.NotImplementedException(); // TODO Implement method
            // TODO Add unit test
        }
    }
}
