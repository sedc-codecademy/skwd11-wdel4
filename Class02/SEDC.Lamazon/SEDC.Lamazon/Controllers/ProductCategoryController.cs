using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.ProductCategory;

namespace SEDC.Lamazon.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

       public ProductCategoryController(IProductCategoryService productCategoryService)
       {
            _productCategoryService = productCategoryService;
       }

        public IActionResult Index()
        {
            var productCategoryViewModels = _productCategoryService.GetAllProductCategories();
            return View(productCategoryViewModels);
        }

        [ActionName("Details")]
        public IActionResult GetById(int id)
        {
            var productCategoryViewModel = _productCategoryService.GetProductCategoryById(id);
            return View(productCategoryViewModel);

        }

        public IActionResult Create()
        {
            var productCategoryViewModel = new ProductCategoryViewModel();
            return View(productCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductCategoryViewModel productCategoryViewModel)
        {
            _productCategoryService.CreateProductCategory(productCategoryViewModel);
            return RedirectToAction("Index");
        }
    }
}
