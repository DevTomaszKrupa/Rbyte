using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbyte.Api.Models.Store;
using Rbyte.Application.Store;

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
            var list = _storehouseService.Get();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _storehouseService.Get(id);
            return Ok(list);
        }

        [HttpPost]
        public void Post([FromBody] ApiStorehouse request)
        {
            _storehouseService.Create(request);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] ApiStorehouse request)
        {
            _storehouseService.Update(request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _storehouseService.Delete(id);
        }
    }
}