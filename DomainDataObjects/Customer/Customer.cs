using DomainDataObjects.Orders;

namespace DomainDataObjects.Customer
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
