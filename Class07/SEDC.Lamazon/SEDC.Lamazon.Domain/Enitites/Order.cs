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
    }
}
