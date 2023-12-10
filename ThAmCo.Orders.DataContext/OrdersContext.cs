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
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<ShippingAddress>()
              .HasKey(ad => ad.ShippingAddressID);

            modelBuilder.Entity<BillingAddress>()
              .HasKey(ad => ad.BillingAddresssID);

            // Define the relationship between Order and Shipping Address
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId);

            // Define the relationship between Order and Billing Address
            modelBuilder.Entity<Order>()
                 .HasOne(o => o.BillingAddress)
                 .WithMany()
                 .OnDelete(DeleteBehavior.ClientSetNull); // Add this line to handle deletion behavior if necessary;

            // Define the many-to-many relationship between Order and OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.OrderItemId); // Assuming OrderItemId is the primary key for OrderItem

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderedItems)
                .WithMany(oi => oi.Orders)
                .UsingEntity(j => j.ToTable("OrderOrderItem"));

        }
    }
}
