using SEDC.Lamazon.Shared.Enums;


namespace SEDC.Lamazon.Domain.Enitites
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual IEnumerable<OrderItem> Items { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalPrice { get; set; }

        public PaymentStatus? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        //shipping
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }
        public DateTime? ShippingDate { get; set; }

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
