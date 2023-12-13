using DomainDTOs.Address;
using DomainDTOs.Customer;
using Enums;

namespace DomainDTOs.Order
{
    public class OrderDTO
    {
        public string OrderId { get; set; }
        public DateTime OrderCreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalPrice { get; set; }
        public double Subtotal { get; set; }
        public double DeliveryCharge { get; set; }
        public string? OrderNotes { get; set; }
        public CustomerDTO Customer { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public ICollection<OrderItemDTO> OrderedItems { get; set; }
        public AddressDTO ShippingAddress { get; set; }
        public CompanyDetailsDTO BillingAddress { get; set; }
    }
}
