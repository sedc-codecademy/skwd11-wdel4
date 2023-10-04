using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lamazon.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Remove(int itemId)
        {
            _orderItemService.DeleteOrderItemById(itemId);

            return RedirectToAction("ShoppingCart", "Order");
        }

    }
}
