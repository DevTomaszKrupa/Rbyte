using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Create;
using Rbyte.Domain.ApiModels.Product;
using System.Collections.Generic;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService _productService { get; set; }

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_productService.Read());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] ApiCreateProduct request)
        {
            _productService.Create(new CreateProductModel
            {
                Barcode = request.Barcode,
                Description = request.Description,
                Name = request.Name,
                Price = request.PriceWithoutMargin
            });
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETEapi/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
