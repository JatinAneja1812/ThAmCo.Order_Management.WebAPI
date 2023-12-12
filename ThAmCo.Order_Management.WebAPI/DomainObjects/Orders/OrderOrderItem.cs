namespace DomainObjects.Orders
{
    public class OrderOrderItem
    {
        public string OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
