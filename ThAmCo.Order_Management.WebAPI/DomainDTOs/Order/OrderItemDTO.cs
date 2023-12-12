namespace DomainDTOs.Order
{
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Img { get; set; }
        public int TotalQuantity { get; set; }
        public string Unit { get; set; }
        public double TotalPrice { get; set; }
        public string BrandName { get; set; }
    }
}
