using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rbyte.Application.Product;
using Rbyte.Application.Product.Create;
using Rbyte.Persistance;

namespace Rbyte.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Products
        public IActionResult Index()
        {
            var list = _productService.Read();
            return View(list);
        }
        // GET: Products/Create
        public IActionResult Create()
        {
            return View(new CreateProductModel());
        }
        // POST: Products/Create
        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            _productService.Create(model);
            return RedirectToAction("Index");
        }
        // GET: Product/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.Read()
                .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // GET: Products/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.Update((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Products/Edit
        [HttpPost]
        public IActionResult Edit(UpdateProductModel model)
        {
            // _productService.Update();
            return RedirectToAction("Index");
        }

        //GET: Products/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.Read()
                .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
