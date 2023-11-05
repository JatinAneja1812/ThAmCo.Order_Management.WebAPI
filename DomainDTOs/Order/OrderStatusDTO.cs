using Enums;

namespace DomainDTOs.Order
{
    public class OrderStatusDTO
    {
        public List<string> OrderId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
