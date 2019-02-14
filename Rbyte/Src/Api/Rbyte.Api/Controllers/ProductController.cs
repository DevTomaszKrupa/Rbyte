using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Create;
using Rbyte.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(List<ProductDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAsync()
        {
            try
            {
                var list = await _productService.GetAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/product/5
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            try
            {
                var product = await _productService.GetAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/product
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PostAsync([FromBody] ProductDto request)
        {
            try
            {
                var id = await _productService.CreateAsync(request);
                return CreatedAtAction(nameof(GetAsync), new { id }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/product/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PutAsync([FromBody] ProductDto request)
        {
            try
            {
                await _productService.UpdateAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex )
            {
                return NotFound(ex.Message);
            }
        }
    }
}
