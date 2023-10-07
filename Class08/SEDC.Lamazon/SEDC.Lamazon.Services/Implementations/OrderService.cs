using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Enums;
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
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userRepository = userRepository;
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

        public OrderViewModel GetActiveOrder(int userId)
        {
            var order = _orderRepository.Get(x => x.UserId == userId && x.IsActive == true, inludeProperties:"Items.Product,User.Role");
            var user = _userRepository.Get(x => x.Id == userId);

            if(order == null)
            {
                var newOrder = new Order
                {
                    UserId = userId,
                    OrderStatus = OrderStatus.Pending,
                    OrderNumber = Guid.NewGuid().ToString(),
                    IsActive = true,
                    PhoneNumber = user.PhoneNumber,
                    StreetAddress = user.StreetAddress,
                    Name = user.FullName,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.State,
                    Items = new List<OrderItem>(),
                };

                _orderRepository.Insert(newOrder);

                return _mapper.Map<OrderViewModel>(newOrder);
            }

            return _mapper.Map<OrderViewModel>(order);
        }

        public List<OrderViewModel> GetAllOrders(int userId)
        {
            List<Order> orders;
            var user = _userRepository.Get(x => x.Id == userId, "Role");

            if(user.Role.Key != "admin")
            {
                orders = _orderRepository.GetAll(x => x.UserId == userId && x.IsActive == false, "Items.Product,User");
            }
            else
            {
                orders = _orderRepository.GetAll(x => x.IsActive == false, "Items.Product,User");
            }         

            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetOrderById(int id)
        {
           var order = _orderRepository.Get(x => x.Id == id, "Items.Product");
            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = _orderRepository.Get(x => x.Id == orderViewModel.Id, "Items.Product");
            order.IsActive = false;
            order.Name = orderViewModel.Name;
            order.PhoneNumber = orderViewModel.PhoneNumber;
            order.StreetAddress = orderViewModel.StreetAddress;
            order.City = orderViewModel.City;
            order.State = orderViewModel.State;
            order.PostalCode = orderViewModel.PostalCode;
            order.OrderDate = DateTime.Now;
            order.TotalPrice = orderViewModel.TotalPrice;
            
            _orderRepository.Update(order);

            return _mapper.Map<OrderViewModel>(order);
        }

        public void UpdateStatus(int orderId, OrderStatus orderStatus, PaymentStatus paymentStatus)
        {
            var order = _orderRepository.Get(x => x.Id == orderId);
            order.OrderStatus = orderStatus;
            order.PaymentStatus = paymentStatus;
            _orderRepository.Update(order);
        }

        public void UpdateStripePayment(int orderId, string sessionId, string paymentIntentId)
        {
            var order = _orderRepository.Get(x => x.Id == orderId);
            if (!string.IsNullOrEmpty(sessionId))
            {
                order.SessionId = sessionId;
            }
            if(!string.IsNullOrEmpty(paymentIntentId))
            {
                order.PaymentIntentId = paymentIntentId;
                order.PaymentDate = DateTime.Now;
            }

            _orderRepository.Update(order);
        }
    }
}
