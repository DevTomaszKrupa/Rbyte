using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using Rbyte.Application.Discount;
using Rbyte.Application.Discount.Create;
using Rbyte.Application.Discount.Update;
using Rbyte.Common.Extensions;

namespace Rbyte.Mvc.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICategoryService _categoryService;
        public DiscountController(IDiscountService discountService,
                                    ICategoryService categoryService)
        {
            _discountService = discountService;
            _categoryService = categoryService;
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
            var categories = _categoryService.GetSelectListItems();
            var model = new CreateDiscountModel
            {
                CategorySelectList = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                model.CategorySelectList = _categoryService.GetSelectListItems();
                return View("Create", model);
            }
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
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Edit", model);
            }
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