using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Product;

namespace SEDC.Lamazon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult ProductDetails(int? id)
        {
            if(id.HasValue)
            {
                var product = _productService.GetProductById(id.Value);
                return View(product);
            }

            return new EmptyResult();
        }

        public IActionResult Create() 
        {
            var productViewModel = new CreateProductViewModel();
            var productCategories = _productCategoryService.GetAllProductCategories();
            ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel createProductViewModel)
        {

            if (ModelState.IsValid)
                {
                _productService.CreateProduct(createProductViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                var productCategories = _productCategoryService.GetAllProductCategories();
                ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

                return View(createProductViewModel);
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id.HasValue)
            {
                var productViewModel = _productService.GetProducForEditById(id.Value);

                var productCategories = _productCategoryService.GetAllProductCategories();
                ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

                return View(productViewModel);

            }

            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateProductViewModel updateProductViewModel) 
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(updateProductViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                var productCategories = _productCategoryService.GetAllProductCategories();
                ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

                return View(updateProductViewModel);
            }
        }

        public IActionResult Delete(int? id)
        {
            if(id.HasValue)
            {
                var productViewModel = _productService.GetProductById(id.Value);
                var productCategories = _productCategoryService.GetAllProductCategories();
                ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

                return View(productViewModel);
            }

            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductViewModel productViewModel)
        {
            _productService.DeleteProductById(productViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}
