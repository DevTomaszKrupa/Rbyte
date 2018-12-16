using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Product;
using Rbyte.Application.Product.Create;
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
            var list = _productService.Get();
            return Ok(list);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var list = _productService.Get(id);
            return Ok(list);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] ApiProduct request)
        {
            _productService.Create(request);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put([FromBody] ApiProduct request)
        {
            _productService.Update(request);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
