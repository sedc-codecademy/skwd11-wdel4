using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var allProducts = StaticDB.Products;
            return View(allProducts);
        }

        public IActionResult ProductDetails(int? id) 
        {
            var product = StaticDB.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                //return View("NotFound");
                return RedirectToAction("NotFound");
            }

            return View(product);
        }

        [ActionName("NotFound")]
        public ActionResult NotFoundPage()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}
