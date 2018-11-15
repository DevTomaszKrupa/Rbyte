using Microsoft.AspNetCore.Mvc;
using Rbyte.Application.Product.Commands.CreateProduct;
using Rbyte.Application.Product.Commands.DeleteProduct;
using Rbyte.Application.Product.Commands.UpdateProduct;
using Rbyte.Application.Product.Queries.GetProductDetails;
using Rbyte.Application.Product.Queries.GetProductsList;

namespace Rbyte.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICreateProductCommandHandler _createProductCommandHandler;
        private readonly IDeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly IUpdateProductCommandHandler _updateProductCommandHandler;
        private readonly IGetProductDetailsQueryHandler _getProductDetailsQueryHandler;
        private readonly IGetProductsListQueryHandler _getProductsListQueryHandler;

        public ProductController(ICreateProductCommandHandler createProductCommandHandler,
                                 IDeleteProductCommandHandler deleteProductCommandHandler,
                                 IUpdateProductCommandHandler updateProductCommandHandler,
                                 IGetProductDetailsQueryHandler getProductDetailsQueryHandler,
                                 IGetProductsListQueryHandler getProductsListQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _getProductDetailsQueryHandler = getProductDetailsQueryHandler;
            _getProductsListQueryHandler = getProductsListQueryHandler;
        }
        public IActionResult Index()
        {
            var list = _getProductsListQueryHandler.Handle();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }       
    }
}
