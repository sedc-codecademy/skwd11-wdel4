using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using System.Security.Claims;

namespace SEDC.Lamazon.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public ShoppingCartViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim == null)
            {
                return View(0);
            }
            var userId = int.Parse(claim.Value);

            var order = _orderService.GetActiveOrder(userId);

            return View(order.Items.Count());

        }
    }
}
