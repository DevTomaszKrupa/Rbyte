using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Store;
using Rbyte.Domain.Models.Storehouse;

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

        [HttpGet]
        public ActionResult Get()
        {
            var list = _storehouseService.GetAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _storehouseService.GetAsync(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] StorehouseDto request)
        {
            _storehouseService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] StorehouseDto request)
        {
            _storehouseService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _storehouseService.DeleteAsync(id);
        }
    }
}