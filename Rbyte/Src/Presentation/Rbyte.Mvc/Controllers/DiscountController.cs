using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Discount;

namespace Rbyte.Mvc.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _discountService.Read();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateDiscountModel());
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountModel model)
        {
            _discountService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var discount = _discountService.Read(id);
            return View(discount);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _discountService.GetForEdition(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(UpdateDiscountModel model)
        {
            _discountService.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _discountService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}