using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var order = orderViewModel.ToOrder(StaticDb.OrderId++);
            var orderId = _orderRepository.Insert(order);
            if(orderId <= 0)
            {
                throw new Exception("Something whent wrong");
            }
        }

        public void DeleteOrderById(int id)
        {
            _orderRepository.DeleteById(id);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(x => x.ToOrderViewModel()).ToList();
        }

        public OrderViewModel GetOrderById(int id)
        {
           var order = _orderRepository.GetById(id);
            return order.ToOrderViewModel();
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = orderViewModel.ToOrder();
            _orderRepository.Update(order);
        }
    }
}
