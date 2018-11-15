using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Create;

namespace Rbyte.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var list = _productService.Read();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new CreateProductModel());
        }       
    }
}
