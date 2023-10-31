namespace DomainDataObjects.Orders
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public DateTime OrderCreationDate { get; set; }

        public string CreatedBy { get; set; }

        public string PaymentMethod { get; set; }

        public double TotalPrice { get; set; }

        public string? OrderNotes { get; set; }     

        public Guid CustomerId { get; set; }

        public DomainDataObjects.Customer.Customer Customer { get; set; }

        public Guid? ShippingAddressId { get; set; } // Foreign key for Shipping Address
        public Address? ShippingAddress { get; set; }
        public Guid? BillingAddressId { get; set; } // Foreign key for Billing Address
        public Address? BillingAddress { get; set; }

        public Guid OrderStatusId { get; set; }
        
        public DomainDataObjects.OrderStatus.OrderStatus Status { get; set; }

        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}