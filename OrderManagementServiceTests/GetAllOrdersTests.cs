using AutoMapper;
using DomainDTOs.Address;
using DomainDTOs.Customer;
using DomainDTOs.Order;
using DomainObjects.Address;
using DomainObjects.Customer;
using DomainObjects.Orders;
using Enums;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using Xunit;

namespace OrderManagementServiceTests
{
    public class GetAllOrdersTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderService _orderService;

        public GetAllOrdersTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mock<IMapper>();

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllOrders_Should_Return_EmptyList_When_NoOrdersFound()
        {
            // Arrange
            _orderRepository.Setup(repo => repo.GetAllOrdersFromDatabase())
                .Returns((List<Order>)null); // Simulating no orders found

            // Act
            var result = _orderService.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllOrders_Should_Map_OrdersTo_OrderDTOs()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { /* Can set order properties */ },
                new Order { /* Can set order properties */ }
                // Add more orders as needed
            };

            var expectedOrderDTOs = new List<OrderDTO>
            {
                new OrderDTO { /* Can set order DTO properties */ },
                new OrderDTO { /* Can set order DTO properties */ }
                // Add more order DTOs as needed
            };

            _orderRepository.Setup(repo => repo.GetAllOrdersFromDatabase())
                .Returns(orders);

            _mapper.Setup(m => m.Map<List<Order>, List<OrderDTO>>(orders))
                .Returns(expectedOrderDTOs);

            // Act
            var result = _orderService.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrderDTOs, result);
        }

        [Fact]
        public void GetAllOrders_Should_Throw_Exception_When_Repository_Fails()
        {
            // Arrange
            _orderRepository.Setup(repo => repo.GetAllOrdersFromDatabase())
                .Throws(new Exception("Simulated repository exception"));

            // Act & Assert
            Assert.Throws<Exception>(() => _orderService.GetAllOrders());
        }

        [Fact]
        public void GetAllOrders_Should_Return_ActualListOfOrders()
        {
            // Arrange
            var orders = new List<Order>
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
                    IsArchived= false,
                    DeliveryCharge = 30.0,
                    OrderNotes = "Urgent delivery",
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
                },

                // Add more orders as needed
            };

            var expectedOrderDTOs = new List<OrderDTO>
            {
                new OrderDTO
                {
                    OrderId = "1",
                    OrderCreationDate = DateTime.Now,
                    DeliveryDate = DateTime.Now.AddDays(7),
                    CreatedBy = "John Doe",
                    PaymentMethod = "Credit Card",
                    TotalPrice = 150.0,
                    Subtotal = 120.0,
                    DeliveryCharge = 30.0,
                    OrderNotes = "Urgent delivery",
                    Status = OrderStatusEnum.Processing,
                    Customer = new CustomerDTO
                    {
                        CustomerId = "123",
                        CustomerName = "Customer Name",
                        // ... initialize other customer DTO properties
                    },
                    OrderedItems = new List<OrderItemDTO>
                    {
                        new OrderItemDTO
                        {
                            ProductId = 1,
                            TotalQuantity = 2,
                            ProductName="Tomato"
                        },
                        new OrderItemDTO
                        {
                            ProductId = 2,
                            TotalQuantity = 4,
                            ProductName="Potato"
                        },
                    },
                    ShippingAddress = new AddressDTO
                    {
                        HouseNumber = "123",
                        Street = "Main Street",
                        City = "City",
                        country = "Country",
                        PostalCode = "12345"
                    },
                    BillingAddress = new CompanyDetailsDTO
                    {
                        CompanyAddressId = "456",
                        CompanyName = "Company Name",
                        ShopNumber = "789",
                        Street = "Company Street",
                        City = "Company City",
                        Country = "Company Country",
                        PostalCode = "67890"
                    }
                },
                // Add more order DTOs as needed
            };

            _orderRepository.Setup(repo => repo.GetAllOrdersFromDatabase())
                .Returns(orders);

            _mapper.Setup(m => m.Map<List<Order>, List<OrderDTO>>(orders))
                .Returns(expectedOrderDTOs);

            // Act
            var result = _orderService.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrderDTOs, result);
            Assert.Equal(result.Count, 1);
        }
    }
}
