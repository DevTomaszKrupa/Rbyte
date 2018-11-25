using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using Rbyte.Application.Product;
using Rbyte.Application.Product.Create;

namespace Rbyte.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
            var model = new CreateProductModel
            {
                CategorySelectList = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
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
