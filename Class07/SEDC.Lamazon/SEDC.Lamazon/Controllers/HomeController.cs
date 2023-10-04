using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Models;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Product;
using System.Diagnostics;
using System.Security.Claims;

namespace SEDC.Lamazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IOrderItemService orderItemService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _orderItemService = orderItemService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult Details(int? id)
        {
            if(id.HasValue)
            {
                bool isInCart = false;

                var product = _productService.GetProductById(id.Value);

                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if(!string.IsNullOrEmpty(userIdString))
                {
                    int userId = int.Parse(userIdString);
                    var activeOrder = _orderService.GetActiveOrder(userId);

                    isInCart = _orderItemService.IsInActiveOrder(product.Id, activeOrder.Id);

                }

                ViewBag.IsInCart = isInCart;

                return View(product);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductViewModel productViewModel)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);
            _orderItemService.CreateOrderItem(productViewModel, userId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
      
    }
}