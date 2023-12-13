using AutoMapper;
using DomainObjects.Orders;
using Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using Xunit;

namespace OrderManagementServiceTests
{
    public class UpdateOrderDeliveryDateTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderService _orderService;

        public UpdateOrderDeliveryDateTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mock<IMapper>();

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper.Object);
        }

        [Fact]
        public void UpdateOrderDeliveryDate_Should_Update_DeliveryDate_And_Return_True()
        {
            // Arrange
            var orderId = "1";
            var scheduledDeliveryDate = DateTime.Now.AddDays(7);

            var existingOrder = new Order
            {
                OrderId = orderId,
                DeliveredDate = DateTime.Now.AddDays(2)
                // ... other order properties
            };

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(existingOrder);

            _orderRepository.Setup(repo => repo.UpdateOrderToDatabase(existingOrder))
                .Returns(1); //  1 means successful update in your repository method

            // Act
            var result = _orderService.UpdateOrderDeliveryDate(orderId, scheduledDeliveryDate);

            // Assert
            Assert.True(result);
            Assert.Equal(scheduledDeliveryDate, existingOrder.DeliveredDate);
            _orderRepository.Verify(repo => repo.UpdateOrderToDatabase(existingOrder), Times.Once);
        }

        [Fact]
        public void UpdateOrderDeliveryDate_Should_Return_False_If_Update_Fails()
        {
            // Arrange
            var orderId = "1";
            var scheduledDeliveryDate = DateTime.Now.AddDays(7);

            var existingOrder = new Order
            {
                OrderId = orderId,
                DeliveredDate = DateTime.Now.AddDays(2)
                // ... other order properties
            };

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(existingOrder);

            _orderRepository.Setup(repo => repo.UpdateOrderToDatabase(existingOrder))
                .Returns(0); //  0 means update failure in your repository method

            // Act
            var result = _orderService.UpdateOrderDeliveryDate(orderId, scheduledDeliveryDate);

            // Assert
            Assert.False(result);
            _orderRepository.Verify(repo => repo.UpdateOrderToDatabase(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void UpdateOrderDeliveryDate_Should_Throw_DataNotFoundException_If_Order_Not_Found()
        {
            // Arrange
            var orderId = "1";
            var scheduledDeliveryDate = DateTime.Now.AddDays(7);

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns((Order)null); // Simulate order not found in the repository

            // Act & Assert
            Assert.Throws<DataNotFoundException>(() => _orderService.UpdateOrderDeliveryDate(orderId, scheduledDeliveryDate));
            _orderRepository.Verify(repo => repo.UpdateOrderToDatabase(It.IsAny<Order>()), Times.Never);
        }
    }
}
