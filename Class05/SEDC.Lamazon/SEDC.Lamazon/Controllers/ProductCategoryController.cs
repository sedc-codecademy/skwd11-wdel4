using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Exceptions.ProductCategory;
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
           try
            {
                if (ModelState.IsValid)
                {
                    _productCategoryService.CreateProductCategory(productCategoryViewModel);
                    return RedirectToAction("Index");
                }

                return View(productCategoryViewModel);
            }
            catch(ProductCategoryException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(productCategoryViewModel);
            }
            catch
            {
                return View("Error");
            }
           
        }

        public IActionResult Edit(int? id)
        {
            if(id.HasValue)
            {
                var productCategoryViewModel = _productCategoryService.GetProductCategoryById(id.Value);
                return View(productCategoryViewModel);

            }

            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategoryViewModel productCategoryViewModel)
        {      
            try
            {
                if (ModelState.IsValid)
                {
                    _productCategoryService.UpdateProductCategory(productCategoryViewModel);

                    return RedirectToAction("Index");
                }

                return View(productCategoryViewModel);
            }
               catch (ProductCategoryException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(productCategoryViewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        public IActionResult Delete(int? id)
        {
            if(id.HasValue)
            {

                var prorductCategoryViewModel = _productCategoryService.GetProductCategoryById(id.Value);
                return View(prorductCategoryViewModel);
            }

            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Delete(ProductCategoryViewModel productCategoryViewModel)
        {
            _productCategoryService.DeleteProductCategoryById(productCategoryViewModel.Id);

            return RedirectToAction("Index");

        }

    }
}
