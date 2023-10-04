using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public void CreateOrderItem(ProductViewModel productViewModel, int userId)
        {
            var order = _orderRepository.Get(x => x.UserId == userId && x.IsActive == true);

            OrderItem orderItem = new OrderItem
            {
                Order = order,
                ProductId = productViewModel.Id,
                Count = 1
            };
            _orderItemRepository.Insert(orderItem);
        }

        public void DeleteOrderItemById(int orderItemId)
        {
            var orderItem = _orderItemRepository.Get(x => x.Id == orderItemId);

            if(orderItem is null)
            {
                throw new Exception("Error");
            }
            _orderItemRepository.Delete(orderItem);
        }

        public bool IsInActiveOrder(int productId, int orderId)
        {
             var orderItem = _orderItemRepository.Get(x => x.ProductId == productId && x.OrderId == orderId);
            if(orderItem == null)
            {
                return false;
            }
            return true;
        }
    }
}
