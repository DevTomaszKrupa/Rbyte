using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Tax;
using Rbyte.Domain.Models.Tax;

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
            var list = _taxService.GetAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _taxService.GetAsync(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] TaxDto request)
        {
            _taxService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] TaxDto request)
        {
            _taxService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taxService.DeleteAsync(id);
        }

    }
}