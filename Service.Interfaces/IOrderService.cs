using DomainDTOs.Order;
using Enums;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDTO> GetAllOrders();

        public List<OrderDTO> GetAllHistoricOrders();

        public int GetAllOrdersCount();

        public bool AddNewOrderByStaff(AddNewOrderDTO orderDTO);

        public bool UpdateOrderStatus(string orderID, OrderStatusEnum orderStatus);

        public bool DeleteOrder(string orderId);
    }
}
