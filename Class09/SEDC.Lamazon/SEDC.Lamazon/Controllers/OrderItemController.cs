using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lamazon.Controllers
{
    [Authorize]
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


        public IActionResult Plus(int itemId)
        {
            _orderItemService.UpdateOrderItem(itemId, 1);
            
            return RedirectToAction("ShoppingCart", "Order");
        }

        public IActionResult Minus(int itemId)
        {
            _orderItemService.UpdateOrderItem(itemId, -1);

            return RedirectToAction("ShoppingCart", "Order");
        }


        public IActionResult Remove(int itemId)
        {
            _orderItemService.DeleteOrderItemById(itemId);

            return RedirectToAction("ShoppingCart", "Order");
        }

    }
}
