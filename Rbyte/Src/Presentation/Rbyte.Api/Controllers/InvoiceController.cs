using Microsoft.AspNetCore.Mvc;
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
    }
}
