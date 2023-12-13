using AutoMapper;
using DomainDTOs.Address;
using DomainDTOs.Customer;
using DomainDTOs.Order;
using DomainObjects.Address;
using DomainObjects.Customer;
using DomainObjects.Orders;
using Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using ThAmCo.Profiles.Mapper;
using Xunit;

namespace OrderManagementServiceTests
{
    public class AddNewOrderByStaffTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly IMapper _mapper;
        private readonly OrderService _orderService;

        public AddNewOrderByStaffTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderProfile>();
            }));

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper);
        }

        [Fact]
        public void AddNewOrderByStaff_Should_ReturnTrue_OnSuccessfulAddition()
        {
            // Arrange
            var orderDTO = new AddNewOrderDTO
            {
                OrderCreationDate = "2023-01-01",
                CreatedBy = "John Doe",
                Subtotal = "100.00",
                DeliveryCharge = "10.00",
                Total = "110.00",
                CustomerId = "123",
                Customer = new CustomerDTO
                {
                    CustomerId = "123",
                    CustomerName = "John Customer",
                    CustomerContactNumber = "1234567890",
                    CustomerEmailAddress = "john.customer@example.com",
                    AvailableFunds = 500.00
                },
                Address = new AddressDTO
                {
                    HouseNumber = "123",
                    Street = "Main Street",
                    City = "Cityville",
                    country = "Countryland",
                    PostalCode = "12345"
                },
                BillingAddress = new CompanyDetailsDTO
                {
                    CompanyAddressId = "456",
                    CompanyName = "Shop ABC",
                    ShopNumber = "456",
                    Street = "Business Street",
                    City = "Business City",
                    Country = "Business Country",
                    PostalCode = "54321"
                },
                OrderedItems = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductId = 1,
                        TotalQuantity = 2,
                        ProductName="Tomato"
                    },
                }
            };

            // Mock existing customer
            var existingCustomer = new Customer
            {
                CustomerId = "123",
                CustomerName = "John Customer",
                CustomerContactNumber = "1234567890",
                CustomerEmailAddress = "john.customer@example.com",
            };

            // Mock repositories
            _orderRepository.Setup(repo => repo.GetCustomerById(It.IsAny<string>()))
                .Returns(existingCustomer);

            _orderRepository.Setup(repo => repo.GetBillingAddressByCriteria(It.IsAny<BillingAddress>()))
                .Returns((BillingAddress)null);

            _orderRepository.Setup(repo => repo.AddNewOrderToDatabase(It.IsAny<Order>()))
                .Returns(1);

            _orderRepository.Setup(repo => repo.AddBillingAddressToDatabase(It.IsAny<BillingAddress>()));
            _orderRepository.Setup(repo => repo.AddCustomerToDatabase(It.IsAny<Customer>()));

            // Act
            var result = _orderService.AddNewOrderByStaff(orderDTO);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddNewOrderByStaff_Should_Throw_RequiredInformationMissingException_If_Data_Is_Incomplete()
        {
            // Arrange
            var orderDTO = new AddNewOrderDTO
            {
                // Incomplete data to trigger exception
            };

            // Act & Assert
            Assert.Throws<RequiredInformationMissingException>(() => _orderService.AddNewOrderByStaff(orderDTO));
        }

        [Fact]
        public void AddNewOrderByStaff_Should_Return_False_If_Addition_Fails()
        {
            // Arrange
            var orderDTO = new AddNewOrderDTO
            {
                OrderCreationDate = "2023-01-01",
                CreatedBy = "John Doe",
                Subtotal = "100.00",
                DeliveryCharge = "10.00",
                Total = "110.00",
                CustomerId = "123",
                Customer = new CustomerDTO
                {
                    CustomerId = "123",
                    CustomerName = "John Customer",
                    CustomerContactNumber = "1234567890",
                    CustomerEmailAddress = "john.customer@example.com",
                    AvailableFunds = 500.00
                },
                Address = new AddressDTO
                {
                    HouseNumber = "123",
                    Street = "Main Street",
                    City = "Cityville",
                    country = "Countryland",
                    PostalCode = "12345"
                },
                BillingAddress = new CompanyDetailsDTO
                {
                    CompanyAddressId = "456",
                    CompanyName = "Shop ABC",
                    ShopNumber = "456",
                    Street = "Business Street",
                    City = "Business City",
                    Country = "Business Country",
                    PostalCode = "54321"
                },
                OrderedItems = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductId = 1,
                        TotalQuantity = 2,
                        ProductName="Tomato"
                    },
                }
            };

            var existingCustomer = new Customer
            {
                CustomerId = "123",
                CustomerName = "John Customer",
                CustomerContactNumber = "1234567890",
                CustomerEmailAddress = "john.customer@example.com",
            };

            _orderRepository.Setup(repo => repo.GetCustomerById(It.IsAny<string>()))
                .Returns((string customerId) =>
                {
                    // Adjust the condition based on your actual usage
                    if (customerId == orderDTO.CustomerId)
                    {
                        return existingCustomer;
                    }

                    return null;
                });


            _orderRepository.Setup(repo => repo.GetBillingAddressByCriteria(It.IsAny<BillingAddress>()))
                .Returns((BillingAddress)null);

            _orderRepository.Setup(repo => repo.AddNewOrderToDatabase(It.IsAny<Order>()))
                .Returns(0); // Assuming 0 means failure in your repository method

            // Act
            var result = _orderService.AddNewOrderByStaff(orderDTO);

            // Assert
            Assert.False(result);
            _orderRepository.Verify(repo => repo.AddCustomerToDatabase(It.IsAny<Customer>()), Times.Never);
        }

        [Fact]
        public void AddNewOrderByStaff_Should_Add_Customer_If_Customer_Not_Already_Exists()
        {
            // Arrange
            var orderDTO = new AddNewOrderDTO
            {
                OrderCreationDate = "2023-01-01",
                CreatedBy = "John Doe",
                Subtotal = "100.00",
                DeliveryCharge = "10.00",
                Total = "110.00",
                CustomerId = "123",
                Customer = new CustomerDTO
                {
                    CustomerId = "123",
                    CustomerName = "John Customer",
                    CustomerContactNumber = "1234567890",
                    CustomerEmailAddress = "john.customer@example.com",
                    AvailableFunds = 500.00
                },
                Address = new AddressDTO
                {
                    HouseNumber = "123",
                    Street = "Main Street",
                    City = "Cityville",
                    country = "Countryland",
                    PostalCode = "12345"
                },
                BillingAddress = new CompanyDetailsDTO
                {
                    CompanyAddressId = "456",
                    CompanyName = "Shop ABC",
                    ShopNumber = "456",
                    Street = "Business Street",
                    City = "Business City",
                    Country = "Business Country",
                    PostalCode = "54321"
                },
                OrderedItems = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductId = 1,
                        TotalQuantity = 2,
                        ProductName="Tomato"
                    },
                }
            };

            _orderRepository.Setup(repo => repo.GetCustomerById(It.IsAny<string>()))
                .Returns((Customer)null);

            _orderRepository.Setup(repo => repo.GetBillingAddressByCriteria(It.IsAny<BillingAddress>()))
            .Returns((BillingAddress)null);

            _orderRepository.Setup(repo => repo.AddNewOrderToDatabase(It.IsAny<Order>()))
                .Returns(1);

            _orderRepository.Setup(repo => repo.AddBillingAddressToDatabase(It.IsAny<BillingAddress>()));
            _orderRepository.Setup(repo => repo.AddCustomerToDatabase(It.IsAny<Customer>()));

            // Act
            var result = _orderService.AddNewOrderByStaff(orderDTO);

            // Assert
            Assert.True(result);
            _orderRepository.Verify(repo => repo.AddCustomerToDatabase(It.IsAny<Customer>()), Times.Once);
        }

    }
}
