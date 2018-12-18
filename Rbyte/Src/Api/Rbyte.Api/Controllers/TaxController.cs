using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Tax;
using Rbyte.Application.Tax;

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

        [HttpGet]
        public ActionResult Get()
        {
            var list = _taxService.Get();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _taxService.Get(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] ApiTax request)
        {
            _taxService.Create(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] ApiTax request)
        {
            _taxService.Update(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taxService.Delete(id);
        }

    }
}