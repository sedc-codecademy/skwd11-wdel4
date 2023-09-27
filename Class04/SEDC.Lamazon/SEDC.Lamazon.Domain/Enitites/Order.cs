using SEDC.Lamazon.Shared.Enums;


namespace SEDC.Lamazon.Domain.Enitites
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
