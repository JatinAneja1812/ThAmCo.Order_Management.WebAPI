using System;

namespace DomainDataObjects.Orders
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public string ProductName { get; set; }
        public string ProductSeller { get; set; }
    }
}