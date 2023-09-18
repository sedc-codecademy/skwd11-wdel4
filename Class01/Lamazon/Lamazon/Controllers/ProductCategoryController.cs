using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            var allCategories = StaticDB.Categories;
            return View(allCategories);
        }

        public IActionResult CategoryDetails(int? id) 
        {
            var category = StaticDB.Categories.FirstOrDefault(c => c.Id == id);

            var products = StaticDB.Products.Where(x => x.Category.Id == id).ToList();
            ViewBag.CategoryName = category.Name;
            return View(products);
        }
    }
}
