using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Mappers
{
    public static class OrderMapper
    {

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                OrderStatus = order.OrderStatus,
                User = order.User.ToUserViewModel(),
            };
        }

        public static Order ToOrderViewModel(this OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                OrderStatus = order.OrderStatus,
                User = order.User.ToUser(),
            };
        }

        public static Order ToOrder(this OrderViewModel order, int nextId)
        {
            return new Order
            {
                Id = nextId,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                OrderStatus = order.OrderStatus,
                User = order.User.ToUser(),
            };
        }

        public static Order ToOrder(this OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                OrderStatus = order.OrderStatus,
                User = order.User.ToUser(),
            };
        }
    }
}
