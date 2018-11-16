using Microsoft.AspNetCore.Mvc;

namespace Rbyte.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
