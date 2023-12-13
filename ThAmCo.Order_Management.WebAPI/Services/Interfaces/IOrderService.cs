using DomainDTOs.Order;
using Enums;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDTO> GetAllOrders();

        public List<OrderDTO> GetAllHistoricOrders();

        public int GetAllOrdersCount();

        public bool AddNewOrderByStaff(AddNewOrderDTO orderDTO);

        public bool UpdateOrderStatus(string orderId, OrderStatusEnum orderStatus);

        public bool UpdateOrderDeliveryDate(string orderId, DateTime scheduledDeliveryDate);

        public bool DeleteOrder(string orderId);
    }
}
