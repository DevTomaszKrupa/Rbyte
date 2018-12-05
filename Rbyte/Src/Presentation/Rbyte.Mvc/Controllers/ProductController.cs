using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using Rbyte.Application.Product.Create;
using Rbyte.Application.Product.Update;
using Rbyte.Application.Tax;
using Rbyte.Common.Extensions;

namespace Rbyte.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ITaxService _taxService;

        public ProductController(IProductService productService,
                                 ICategoryService categoryService,
                                 ITaxService taxService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _taxService = taxService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _productService.Read();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetSelectListItems();
            var taxes = _taxService.GetTaxSelectList();
            var model = new CreateProductModel
            {
                CategorySelectList = categories,
                TaxSelectList = taxes
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                model.CategorySelectList = _categoryService.GetSelectListItems();
                model.TaxSelectList = _taxService.GetTaxSelectList();
                return View("Create", model);
            }

            _productService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productService.Read(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetForEdition(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Edit", model);
            }
            _productService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
