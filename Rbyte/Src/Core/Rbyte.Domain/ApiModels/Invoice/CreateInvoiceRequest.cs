using System;

namespace Rbyte.Domain.ApiModels.Invoice
{
    public class CreateInvoiceRequest
    {
        public string InvoiceNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string CompanyName { get; set; }
    }
}
