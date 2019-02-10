using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Discount;
using Rbyte.Domain.Models.Discount;

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

        [HttpGet]
        public ActionResult Get()
        {
            var list = _discountService.GetAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _discountService.GetAsync(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] DiscountDto request)
        {
            _discountService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] DiscountDto request)
        {
            _discountService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _discountService.DeleteAsync(id);
        }
    }
}