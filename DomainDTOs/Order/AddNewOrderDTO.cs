using DomainDTOs.Address;
using DomainDTOs.Customer;
using Enums;

namespace DomainDTOs.Order
{
    public class AddNewOrderDTO
    {
        public string OrderCreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string? OrderNotes { get; set; }
        public string Subtotal { get; set; }
        public string DeliveryCharge { get; set; }
        public string Total { get; set; }
        public string CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public AddressDTO Address { get; set; }
        public CompanyDetailsDTO? BillingAddress { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public List<OrderItemDTO> OrderedItems { get; set; }
    }
}
