using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SEDC.Lamazon.Services;
using SEDC.Lamazon.Services.Implementations;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Enums;
using SEDC.Lamazon.ViewModels.Models.Email;
using SEDC.Lamazon.ViewModels.Models.Order;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace SEDC.Lamazon.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        private readonly EmailTemplateGenerator _emailTemplateGenerator;

        [BindProperty]
        public OrderViewModel OrderViewModel { get; set; }

        public OrderController(IOrderService orderService, IEmailService emailService, EmailTemplateGenerator emailTemplateGenerator)
        {
            _orderService = orderService;
            _emailService = emailService;
            _emailTemplateGenerator = emailTemplateGenerator;
        }
        public IActionResult Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var orders = _orderService.GetAllOrders(userId);

            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var order = _orderService.GetActiveOrder(userId);

            return View(order);
        }

        public IActionResult Summary()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var order = _orderService.GetActiveOrder(userId);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            if(OrderViewModel.UserId != userId)
            {
                RedirectToAction("Error", "Home");
            }

            OrderViewModel = _orderService.SubmitOrder(OrderViewModel);

            var domain = "https://localhost:7106";

            var options = new SessionCreateOptions
            {
               SuccessUrl = $"{domain}/Order/Confirmation?id={OrderViewModel.Id}",
               CancelUrl = $"{domain}/Order/ShoppingCart",
               Mode = "payment",
               LineItems = new List<SessionLineItemOptions>(),
            };

            foreach(var item in OrderViewModel.Items)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name,
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            _orderService.UpdateStripePayment(OrderViewModel.Id, session.Id, session.PaymentIntentId);
        
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult Confirmation(int id)
        {
            var order = _orderService.GetOrderById(id);

            var service = new SessionService();
            Session session = service.Get(order.SessionId);

            if(session.PaymentStatus.ToLower() == "paid")
            {
                _orderService.UpdateStripePayment(id, session.Id, session.PaymentIntentId);
                _orderService.UpdateStatus(id, OrderStatus.Accepted, PaymentStatus.Approved);
            }

            return View(order);
        }

        public IActionResult Details(int id)
        {
            var orderViewModel = _orderService.GetOrderById(id);

            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateOrderDetail()
        {
            _orderService.UpdateOrder(OrderViewModel);
            return RedirectToAction(nameof(Details), new {id = OrderViewModel.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult StartProcessing()
        {
            _orderService.UpdateStatus(OrderViewModel.Id, OrderStatus.Processing);
            TempData["success"] = "Order is proccessing!";
            return RedirectToAction(nameof(Details), new { id = OrderViewModel.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ShipOrder()
        {
            _orderService.ShipOrder(OrderViewModel);

            var orderViewModel = _orderService.GetOrderById(OrderViewModel.Id);
            string content = await _emailTemplateGenerator.RenderViewToStringAsync("Shared/Email/_OrderDetails", orderViewModel);

            var emailViewModel = new EmailViewModel
            {
                To = OrderViewModel.User.Email,
                Subject = "Order Shippment",
                Body = content
            };

            _emailService.SendEmail(emailViewModel);

            TempData["success"] = "Order is shipped!";
            return RedirectToAction(nameof(Details), new { id = OrderViewModel.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult CancelOrder()
        {
            if(OrderViewModel.PaymentStatus == PaymentStatus.Approved)
            {
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = OrderViewModel.PaymentIntentId
                };

                var service = new RefundService();
                Refund refund = service.Create(options);

                _orderService.UpdateStatus(OrderViewModel.Id, OrderStatus.Refunded);

            }
            else
            {
                _orderService.UpdateStatus(OrderViewModel.Id, OrderStatus.Cancelled);
            }

            TempData["success"] = "Order Cancelled Successfully!";
            return RedirectToAction(nameof(Details), new { id = OrderViewModel.Id });
        }
    }
}
