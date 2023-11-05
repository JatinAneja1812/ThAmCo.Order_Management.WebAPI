using Enums;
using System.ComponentModel.DataAnnotations;

namespace DomainDataObjects.Orders
{
    public class HistoricOrder
    {
        private DateTime _orderCreateDate;
        private DateTime _archivedDateTime;
        private DateTime _orderDeliveredDate;

        [Key]
        public Guid HistoricOrderId { get; set; }
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
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNumber { get; set; }
        public OrderStatusEnum Status { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
        public Guid ShippingAddressId { get; set; }
        public DomainDataObjects.Address.ShippingAddress ShippingAddress { get; set; }
        public Guid BillingAddressId { get; set; }
        public DomainDataObjects.Address.BillingAddress BillingAddress { get; set; }
        public bool IsCreatedByStaff { get; set; }
        public DateTime DeliveredDate
        {
            get => _orderDeliveredDate;

            set => _orderDeliveredDate = value.ToUniversalTime();
        }
        public bool IsArchieved { get; set; }
        public DateTime ArchievedDateTime
        {
            get => _archivedDateTime;

            set => _archivedDateTime = value.ToUniversalTime();
        }
    }
}

