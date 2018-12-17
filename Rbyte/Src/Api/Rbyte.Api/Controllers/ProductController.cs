using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Product;
using Rbyte.Application.Product.Create;
using System.Collections.Generic;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _productService { get; set; }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var list = _productService.Get();
            return Ok(list);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var list = _productService.Get(id);
            return Ok(list);
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody] ApiProduct request)
        {
            _productService.Create(request);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put([FromBody] ApiProduct request)
        {
            _productService.Update(request);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
