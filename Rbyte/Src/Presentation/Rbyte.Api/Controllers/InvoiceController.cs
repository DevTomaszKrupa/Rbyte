using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.ApiModels.Invoice;
using System.Collections.Generic;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        // GET api/invoice
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "invoice1", "invoice2" };
        }

        [HttpPost]
        public ActionResult Create(CreateInvoiceRequest request)
        {
            return null;
        }
    }
}
