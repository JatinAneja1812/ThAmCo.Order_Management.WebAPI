using System;

namespace DomainDataObjects.Orders
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public string ProductSeller { get; set; }
    }
}