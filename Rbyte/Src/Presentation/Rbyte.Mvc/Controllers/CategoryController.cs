using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Category;
using System.Linq;

namespace Rbyte.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _categoryService.Read();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCategoryModel());
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryModel model)
        {
            _categoryService.Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _categoryService.Read(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetForEdition(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryModel model)
        {
            _categoryService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
