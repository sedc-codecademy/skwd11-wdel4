using SEDC.Lamazon.Shared.Enums;
using SEDC.Lamazon.ViewModels.Models.OrderItem;
using SEDC.Lamazon.ViewModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public decimal TotalPrice { get; set; }

        public PaymentStatus? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }

    }
}
