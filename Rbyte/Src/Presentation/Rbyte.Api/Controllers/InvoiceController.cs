using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Invoice;
using Rbyte.Domain.ApiModels.Invoice;
using System.Collections.Generic;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceCreator _invoiceCreator;

        public InvoiceController(IInvoiceCreator invoiceCreator)
        {
            _invoiceCreator = invoiceCreator;
        }

        // GET api/invoice
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "invoice1", "invoice2" };
        }

        // POST api/invoice
        [HttpPost]
        public ActionResult Create(CreateInvoiceRequest request)
        {
            _invoiceCreator.Create(request);
            return Ok();
        }
    }
}
