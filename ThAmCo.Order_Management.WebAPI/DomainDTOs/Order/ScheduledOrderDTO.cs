using DomainDTOs.Address;

namespace DomainDTOs.Order
{
    public class ScheduledOrderDTO
    {
        public Guid OrderId { get; set; }
        public string ShippingAddressId { get; set; }
        public AddressDTO ShippingAddress { get; set; }
        public string BillingAddressId { get; set; }
        public AddressDTO BillingAddress { get; set; }
    }
}
 