using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using Rbyte.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET api/category
        [ProducesResponseType(typeof(List<CategoryDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var list = await _categoryService.GetAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/category/5
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var list = await _categoryService.GetAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST api/category
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryDto request)
        {
            try
            {              
                var id = await _categoryService.CreateAsync(request);
                return CreatedAtAction(nameof(GetAsync), new { id }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        // PUT api/category/5
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] CategoryDto request)
        {
            try
            {
                await _categoryService.UpdateAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}