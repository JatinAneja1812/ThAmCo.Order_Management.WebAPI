using DomainDataObjects.Address;
using DomainDataObjects.Customer;
using DomainDataObjects.Orders;
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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<HistoricOrder> HistoricOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.ProductId);

            modelBuilder.Entity<HistoricOrder>()
               .HasKey(o => o.HistoricOrderId);

            modelBuilder.Entity<ShippingAddress>()
              .HasKey(ad => ad.ShippingAddressID);

            modelBuilder.Entity<BillingAddress>()
              .HasKey(ad => ad.BillingAddresssID);

            // Configure the one-to-many relationship between Customer and Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)  // Each order has one customer
                .WithMany(c => c.Orders)  // Each customer can have many orders
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

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

            // Define the relationship between Order and Shipping Address
            modelBuilder.Entity<HistoricOrder>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId);

            // Define the relationship between Order and Billing Address
            modelBuilder.Entity<HistoricOrder>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
