﻿using Enums;
using System.ComponentModel.DataAnnotations;

namespace DomainObjects.Orders
{
    public class Order
    {
        private DateTime _orderCreateDate;
        private DateTime _orderDeliveredDate;

        [Key]
        public string OrderId { get; set; }
        public DateTime OrderCreationDate
        {
            get => _orderCreateDate;

            set => _orderCreateDate = value.ToUniversalTime();
        }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; } = "Availablefunds";
        public double TotalPrice { get; set; }
        public double Subtotal { get; set; }
        public double DeliveryCharge { get; set; }
        public string? OrderNotes { get; set; }     
        public OrderStatusEnum? Status { get; set; }
        public bool isCreatedByStaff { get; set; }
        public DateTime DeliveredDate
        {
            get => _orderDeliveredDate;

            set => _orderDeliveredDate = value.ToUniversalTime();
        }
        public string CustomerId { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public DomainObjects.Customer.Customer Customer { get; set; }
        public string? ShippingAddressId { get; set; }
        public DomainObjects.Address.ShippingAddress? ShippingAddress { get; set; }
        public string? BillingAddressId { get; set; }
        public DomainObjects.Address.BillingAddress? BillingAddress { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}