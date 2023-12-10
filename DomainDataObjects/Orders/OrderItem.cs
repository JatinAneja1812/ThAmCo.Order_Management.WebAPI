using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainDataObjects.Orders
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; } // New primary key
        public int ProductId { get; set; }    // Regular column
        public string ProductName { get; set; }
        public string Img { get; set; }
        public int TotalQuantity { get; set; }
        public string Unit { get; set; }
        public double TotalPrice { get; set; }
        public string BrandName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}