using DomainDataObjects.Orders;
using Enums;

namespace DomainDataObjects.OrderStatus
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public Order Order { get; set; } // An order status is associated with one order
    }
}
