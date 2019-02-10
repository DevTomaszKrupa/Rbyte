using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using Rbyte.Domain.Models.Category;

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
        [HttpGet]
        public ActionResult Get()
        {
            var list = _categoryService.GetAsync();
            return Ok(list);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _categoryService.GetAsync(id);
            return Ok(list);
        }

        // POST api/category
        [HttpPost]
        public void Post([FromBody] CategoryDto request)
        {
            _categoryService.CreateAsync(request);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public void Put([FromBody] CategoryDto request)
        {
            _categoryService.UpdateAsync(request);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteAsync(id);
        }

    }
}