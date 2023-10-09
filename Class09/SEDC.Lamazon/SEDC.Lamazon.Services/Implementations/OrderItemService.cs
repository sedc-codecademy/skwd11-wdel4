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
        private readonly IProductRepository _productRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void CreateOrderItem(int productId, int userId)
        {
            var order = _orderRepository.Get(x => x.UserId == userId && x.IsActive == true);
            var product = _productRepository.Get(x => x.Id == productId);

            OrderItem orderItem = new OrderItem
            {
                Order = order,
                ProductId = product.Id,
                Count = 1,
                Price = product.Price
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

        public void UpdateOrderItem(int itemId, int change)
        {
            var orderItem = _orderItemRepository.Get(x => x.Id == itemId);
            if(orderItem == null)
            {
                throw new Exception("Error");
            }
            if(change < 0 && orderItem.Count == 1)
            {
                return;
            }

            orderItem.Count += change;
            _orderItemRepository.Update(orderItem);

        }
    }
}
