using DomainDataObjects.Customer;
using DomainDataObjects.Orders;
using DomainDataObjects.OrderStatus;
using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Orders.DataContext
{
    public class OrdersContext : DbContext
    {
        public OrdersContext() : base()
        {
        }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderStatus>()
                .HasKey(os => os.OrderStatusId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.ProductId);

            // Define the relationship between Order and Shipping Address
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId);

            // Define the relationship between Order and Billing Address
            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId);

            // Define the one-to-one relationship between Order and Order Status
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithOne(os => os.Order)
                .HasForeignKey<OrderStatus>(os => os.OrderStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}
