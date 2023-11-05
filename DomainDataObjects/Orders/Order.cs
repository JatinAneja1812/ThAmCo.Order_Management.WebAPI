using Enums;
using System.ComponentModel.DataAnnotations;

namespace DomainDataObjects.Orders
{
    public class Order
    {
        private DateTime _orderCreateDate;
        private DateTime _orderDeliveredDate;

        [Key]
        public Guid OrderId { get; set; }
        public DateTime OrderCreationDate
        {
            get => _orderCreateDate;

            set => _orderCreateDate = value.ToUniversalTime();
        }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalPrice { get; set; }
        public string? OrderNotes { get; set; }     
        public Guid CustomerId { get; set; }
        public DomainDataObjects.Customer.Customer Customer { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
        public Guid? ShippingAddressId { get; set; }
        public DomainDataObjects.Address.ShippingAddress? ShippingAddress { get; set; }
        public Guid? BillingAddressId { get; set; }
        public DomainDataObjects.Address.BillingAddress? BillingAddress { get; set; }
        public bool isCreatedByStaff { get; set; }
        public DateTime DeliveredDate
        {
            get => _orderDeliveredDate;

            set => _orderDeliveredDate = value.ToUniversalTime();
        }

    }
}