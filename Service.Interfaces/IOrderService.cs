using DomainDTOs.Order;
using Enums;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDTO> GetAllOrders();
        
        public List<OrderDTO> GetOrdersById(string orderId);

        public bool AddNewOrderByStaff(AddNewOrderDTO orderDTO);

        public bool UpdateOrderStatus(string orderID, OrderStatusEnum orderStatus);
    }
}
