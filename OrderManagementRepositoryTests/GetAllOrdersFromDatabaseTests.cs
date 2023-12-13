using DataContext;
using DomainObjects.Address;
using DomainObjects.Customer;
using DomainObjects.Orders;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ThAmCo.Order_Management.WebAPI.Repositories.Classes;
using Xunit;

namespace OrderManagementRepositoryTests
{
    public class GetAllOrdersFromDatabaseTests
    {
        private readonly OrderRepository _orderRepository;
        private readonly Mock<OrdersContext> _contextMock;
        private readonly Mock<ILogger<OrderRepository>> _loggerMock;

        public GetAllOrdersFromDatabaseTests()
        {
            // Arrange
            _contextMock = new Mock<OrdersContext>();
            _loggerMock = new Mock<ILogger<OrderRepository>>();

            _orderRepository = new OrderRepository(_contextMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetAllOrdersFromDatabase_Should_Return_Orders_List_From_The_Database()
        {
            //Arrange
            Mock<DbSet<Order>> mockOrdersDbSet = new Mock<DbSet<Order>>();

            var data = new List<Order>
            {
                new Order
                {
                    OrderId = "1",
                    OrderCreationDate = DateTime.Now,
                    DeliveredDate = DateTime.Now.AddDays(7),
                    CreatedBy = "John Doe",
                    PaymentMethod = "Credit Card",
                    TotalPrice = 150.0,
                    Subtotal = 120.0,
                    IsArchived= true,
                    DeliveryCharge = 30.0,
                    OrderNotes = "Urgent delivery",
                    Status = OrderStatusEnum.Delivered,
                    Customer = new Customer
                    {
                        CustomerId = "123",
                        CustomerName = "Customer Name",
                    },
                    OrderedItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            ProductId = 1,
                            TotalQuantity = 2,
                            ProductName="Tomato"
                        },
                        new OrderItem
                        {
                            ProductId = 2,
                            TotalQuantity = 4,
                            ProductName="Potato"
                        },
                    },
                    ShippingAddress = new ShippingAddress
                    {
                        ShippingAddressID = "12312ghiu3h",
                        ShippingAddress_HouseNumber = "123",
                        ShippingAddress_Street = "Main Street",
                        ShippingAddress_City = "City",
                        ShippingAddress_Country = "Country",
                        ShippingAddress_PostalCode = "12345"
                    },
                    BillingAddress = new BillingAddress
                    {
                        BillingAddresssID = "dedqw97qd",
                        BillingAddresss_Shopname = "Company Name",
                        BillingAddresss_Shopnumber = "789",
                        BillingAddresss_Street = "Company Street",
                        BillingAddresss_City = "Company City",
                        BillingAddresss_Country = "Company Country",
                        BillingAddresss_PostalCode = "67890"
                    }
                },
                new Order
                {
                    OrderId = "3",
                    OrderCreationDate = DateTime.Now,
                    DeliveredDate = DateTime.Now.AddDays(7),
                    CreatedBy = "John Kiev",
                    PaymentMethod = "Credit Card",
                    TotalPrice = 1350.0,
                    Subtotal = 1240.0,
                    IsArchived= false,
                    DeliveryCharge = 320.0,
                    OrderNotes = null,
                    Status = OrderStatusEnum.Processing,
                    Customer = new Customer
                    {
                        CustomerId = "123",
                        CustomerName = "Customer Name",
                    },
                    OrderedItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            ProductId = 1,
                            TotalQuantity = 2,
                            ProductName="Tomato"
                        },
                        new OrderItem
                        {
                            ProductId = 2,
                            TotalQuantity = 4,
                            ProductName="Potato"
                        },
                    },
                    ShippingAddress = new ShippingAddress
                    {
                        ShippingAddressID = "12312ghiu3h",
                        ShippingAddress_HouseNumber = "123",
                        ShippingAddress_Street = "Main Street",
                        ShippingAddress_City = "City",
                        ShippingAddress_Country = "Country",
                        ShippingAddress_PostalCode = "12345"
                    },
                    BillingAddress = new BillingAddress
                    {
                        BillingAddresssID = "dedqw97qd",
                        BillingAddresss_Shopname = "Company Name",
                        BillingAddresss_Shopnumber = "789",
                        BillingAddresss_Street = "Company Street",
                        BillingAddresss_City = "Company City",
                        BillingAddresss_Country = "Company Country",
                        BillingAddresss_PostalCode = "67890"
                    }
                }
                // Add more orders as needed
            }.AsQueryable();

            mockOrdersDbSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockOrdersDbSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockOrdersDbSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockOrdersDbSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _contextMock.SetupGet(c => c.Orders).Returns(mockOrdersDbSet.Object);

            //Act
            var result = _orderRepository.GetAllOrdersFromDatabase();

            //Assert
            IEnumerable<Order> actual = result.ToList();
            //Assert
            Assert.True(result != null);
            Assert.Equal(1, actual.Count());
            Assert.True(actual.ToList()[0].OrderId == "3");
        }

        [Fact]
        public void Should_Fail_If_Context_Returns_Null()
        {
            // Arrange
            Mock<DbSet<Order>> mockOrdersDbSet = new Mock<DbSet<Order>>();

            var data = new List<Order>
            {
                new Order
                {
                    OrderId = "1",
                    OrderCreationDate = DateTime.Now,
                    DeliveredDate = DateTime.Now.AddDays(7),
                    CreatedBy = "John Doe",
                    PaymentMethod = "Credit Card",
                    TotalPrice = 150.0,
                    Subtotal = 120.0,
                    IsArchived= true,
                    DeliveryCharge = 30.0,
                    OrderNotes = "Urgent delivery",
                    Status = OrderStatusEnum.Delivered,
                    Customer = new Customer
                    {
                        CustomerId = "123",
                        CustomerName = "Customer Name",
                    },
                    OrderedItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            ProductId = 1,
                            TotalQuantity = 2,
                            ProductName="Tomato"
                        },
                        new OrderItem
                        {
                            ProductId = 2,
                            TotalQuantity = 4,
                            ProductName="Potato"
                        },
                    },
                    ShippingAddress = new ShippingAddress
                    {
                        ShippingAddressID = "12312ghiu3h",
                        ShippingAddress_HouseNumber = "123",
                        ShippingAddress_Street = "Main Street",
                        ShippingAddress_City = "City",
                        ShippingAddress_Country = "Country",
                        ShippingAddress_PostalCode = "12345"
                    },
                    BillingAddress = new BillingAddress
                    {
                        BillingAddresssID = "dedqw97qd",
                        BillingAddresss_Shopname = "Company Name",
                        BillingAddresss_Shopnumber = "789",
                        BillingAddresss_Street = "Company Street",
                        BillingAddresss_City = "Company City",
                        BillingAddresss_Country = "Company Country",
                        BillingAddresss_PostalCode = "67890"
                    }
                },
                new Order
                {
                    OrderId = "3",
                    OrderCreationDate = DateTime.Now,
                    DeliveredDate = DateTime.Now.AddDays(7),
                    CreatedBy = "John Kiev",
                    PaymentMethod = "Credit Card",
                    TotalPrice = 1350.0,
                    Subtotal = 1240.0,
                    IsArchived= false,
                    DeliveryCharge = 320.0,
                    OrderNotes = null,
                    Status = OrderStatusEnum.Processing,
                    Customer = new Customer
                    {
                        CustomerId = "123",
                        CustomerName = "Customer Name",
                    },
                    OrderedItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            ProductId = 1,
                            TotalQuantity = 2,
                            ProductName="Tomato"
                        },
                        new OrderItem
                        {
                            ProductId = 2,
                            TotalQuantity = 4,
                            ProductName="Potato"
                        },
                    },
                    ShippingAddress = new ShippingAddress
                    {
                        ShippingAddressID = "12312ghiu3h",
                        ShippingAddress_HouseNumber = "123",
                        ShippingAddress_Street = "Main Street",
                        ShippingAddress_City = "City",
                        ShippingAddress_Country = "Country",
                        ShippingAddress_PostalCode = "12345"
                    },
                    BillingAddress = new BillingAddress
                    {
                        BillingAddresssID = "dedqw97qd",
                        BillingAddresss_Shopname = "Company Name",
                        BillingAddresss_Shopnumber = "789",
                        BillingAddresss_Street = "Company Street",
                        BillingAddresss_City = "Company City",
                        BillingAddresss_Country = "Company Country",
                        BillingAddresss_PostalCode = "67890"
                    }
                }
                // Add more orders as needed
            }.AsQueryable();

            _contextMock.SetupGet(c => c.Orders).Returns((DbSet<Order>)null); // Simulate _context.Users returning null

            var result = _orderRepository.GetAllOrdersFromDatabase();

            // Act and Assert
            Assert.Null(result);
        }
    }
}
