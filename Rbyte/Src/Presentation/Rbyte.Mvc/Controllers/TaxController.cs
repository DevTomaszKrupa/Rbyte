using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Tax;
using Rbyte.Application.Tax.Create;
using Rbyte.Application.Tax.Update;
using Rbyte.Common.Extensions;

namespace Rbyte.Mvc.Controllers
{
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _taxService.Read();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTaxModel());
        }

        [HttpPost]
        public IActionResult Create(CreateTaxModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Create", model);
            }
            _taxService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var tax = _taxService.Read(id);
            return View(tax);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tax = _taxService.GetForEdition(id);
            return View(tax);
        }

        [HttpPost]
        public IActionResult Edit(UpdateTaxModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Edit", model);
            }
            _taxService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _taxService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}