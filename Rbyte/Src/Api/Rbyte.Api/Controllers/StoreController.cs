using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Store;
using Rbyte.Domain.Models.Storehouse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public IStorehouseService _storehouseService { get; set; }

        public StoreController(IStorehouseService storehouseService)
        {
            _storehouseService = storehouseService;
        }

        // GET api/store
        [ProducesResponseType(typeof(List<StorehouseDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var list = await _storehouseService.GetAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/store/4
        [ProducesResponseType(typeof(StorehouseDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var list = await _storehouseService.GetAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/store
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PostAsync([FromBody] StorehouseDto request)
        {
            try
            {
                var id = await _storehouseService.CreateAsync(request);
                return CreatedAtAction(nameof(GetAsync), new { id }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/store/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PutAsync([FromBody] StorehouseDto request)
        {
            try
            {
                await _storehouseService.UpdateAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/store/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _storehouseService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}