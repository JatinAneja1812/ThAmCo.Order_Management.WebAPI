using DomainDTOs.Address;
using DomainDTOs.Customer;
using Enums;

namespace DomainDTOs.Order
{
    public class ScheduledOrderDTO
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
        public string ShippingAddressId { get; set; }
        public AddressDTO ShippingAddress { get; set; }
        public string BillingAddressId { get; set; }
        public AddressDTO BillingAddress { get; set; }
    }
}
