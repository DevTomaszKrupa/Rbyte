using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Tax;
using Rbyte.Domain.Models.Tax;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        public ITaxService _taxService { get; set; }

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        // GET api/tax
        [ProducesResponseType(typeof(List<TaxDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var list = await _taxService.GetAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        // GET api/tax/5
        [ProducesResponseType(typeof(TaxDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var list = await _taxService.GetAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/tax
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PostAsync([FromBody] TaxDto request)
        {
            try
            {
                var id = await _taxService.CreateAsync(request);
                return CreatedAtAction(nameof(GetAsync), new { id }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/tax/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PutAsync([FromBody] TaxDto request)
        {
            try
            {
                await _taxService.UpdateAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/tax/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _taxService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}