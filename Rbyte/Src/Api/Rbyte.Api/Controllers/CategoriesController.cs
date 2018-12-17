using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Category;
using Rbyte.Application.Category;

namespace Rbyte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ICategoryService _categoryService { get; set; }
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET api/categories
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var list = _categoryService.Get();
            return Ok(list);
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var list = _categoryService.Get(id);
            return Ok(list);
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody] ApiCategory request)
        {
            _categoryService.Create(request);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put([FromBody] ApiCategory request)
        {
            _categoryService.Update(request);
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }

    }
}