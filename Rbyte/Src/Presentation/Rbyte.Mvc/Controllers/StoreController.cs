using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Create;
using Rbyte.Application.Store;
using Rbyte.Application.Store.Add;
using Rbyte.Application.Store.Create;
using Rbyte.Application.Store.Update;
using Rbyte.Common.Extensions;

namespace Rbyte.Mvc.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        public StoreController(IStoreService storeService,
                                IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
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
        public IActionResult AddProduct(int id)
        {
            var store = _storeService.GetForAdd(id);
            var products = _productService.GetProductSelectList();
            store.ProductSelectList = products;
            return View(store);
        }

        [HttpPost]
        public IActionResult AddProduct(AddStoreProductModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.GetAllErrorMessages();
                model.ProductSelectList = _productService.GetProductSelectList();
                return View("AddProduct", model);
            }
            _storeService.AddProduct(model);
            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            _storeService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}