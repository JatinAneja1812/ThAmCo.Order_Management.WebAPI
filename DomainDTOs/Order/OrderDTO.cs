using DomainDTOs.Customer;
using Enums;

namespace DomainDTOs.Order
{
    public class OrderDTO
    {
        public string OrderId { get; set; }
        public DateTime OrderCreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalPrice { get; set; }
        public string? OrderNotes { get; set; }
        public string CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public ICollection<OrderItemDTO> OrderedItems { get; set; }
    }
}
