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
        List<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void UpdateOrder(OrderViewModel orderViewModel);
        void DeleteOrderById(int id);

    }
}
