using Enums;

namespace DomainDTOs.Order
{
    public class OrderStatusDTO
    {
        public string OrderId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
