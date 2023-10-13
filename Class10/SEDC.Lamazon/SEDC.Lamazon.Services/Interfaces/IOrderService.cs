using SEDC.Lamazon.Shared.Enums;
using SEDC.Lamazon.ViewModels.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAllOrders(int userId, string? status = null);
        OrderViewModel GetOrderById(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        OrderViewModel UpdateOrder(OrderViewModel orderViewModel);
        OrderViewModel SubmitOrder(OrderViewModel orderViewModel);
        void DeleteOrderById(int id);
        OrderViewModel GetActiveOrder(int userId);
        void ShipOrder(OrderViewModel orderViewModel);
        void UpdateStripePayment(int orderId, string sessionId, string paymentIntentId);
        void UpdateStatus(int orderId, OrderStatus orderStatus, PaymentStatus? paymentStatus = null);
    }
}
