using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
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
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
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

            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetOrderById(int id)
        {
           var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
            _orderRepository.Update(order);
        }
    }
}
