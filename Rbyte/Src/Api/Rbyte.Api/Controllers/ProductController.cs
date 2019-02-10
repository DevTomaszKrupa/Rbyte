using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Create;
using Rbyte.Domain.Models.Product;

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
        public ActionResult Get()
        {
            var list = _productService.GetAsync();
            return Ok(list);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _productService.GetAsync(id);
            return Ok(list);
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody] ProductDto request)
        {
            _productService.CreateAsync(request);
           // TODO  return Created();
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put([FromBody] ProductDto request)
        {
            _productService.UpdateAsync(request);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteAsync(id);
        }
    }
}
