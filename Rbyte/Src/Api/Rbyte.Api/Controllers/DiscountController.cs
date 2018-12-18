using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Discount;
using Rbyte.Application.Discount;

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
            var list = _discountService.Get();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _discountService.Get(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] ApiDiscount request)
        {
            _discountService.Create(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] ApiDiscount request)
        {
            _discountService.Update(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _discountService.Delete(id);
        }
    }
}