using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Store;
using Rbyte.Application.Store.Create;
using Rbyte.Application.Store.Update;
using Rbyte.Common.Extensions;

namespace Rbyte.Mvc.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _storeService.Read();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateStoreModel());
        }

        [HttpPost]
        public IActionResult Create(CreateStoreModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Create", model);
            }
            _storeService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var store = _storeService.Read(id);
            return View(store);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var store = _storeService.GetForEdition(id);
            return View(store);
        }

        [HttpPost]
        public IActionResult Edit(UpdateStoreModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                return View("Edit", model);
            }
            _storeService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _storeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}