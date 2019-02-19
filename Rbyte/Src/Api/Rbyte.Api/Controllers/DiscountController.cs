using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Discount;
using Rbyte.Domain.Models.Discount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        public IDiscountService _discountService { get; set; }

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // GET api/discount
        [ProducesResponseType(typeof(List<DiscountDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var list = await _discountService.GetAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/discount/5
        [ProducesResponseType(typeof(DiscountDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var list = await _discountService.GetAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/discount
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] DiscountDto request)
        {
            try
            {
                var id = await _discountService.CreateAsync(request);
                return CreatedAtAction(nameof(GetAsync), new { id}, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/discount/5
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] DiscountDto request)
        {
            try
            {
                await _discountService.UpdateAsync(request);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/discount/5
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _discountService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}